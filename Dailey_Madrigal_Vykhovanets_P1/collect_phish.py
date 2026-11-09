#!/usr/bin/env python3
"""
collect_phish.py — Project 1 starter collector (CSCI U550, Fall 2026)

Collects phishing URLs from the OpenPhish community feed, two ways:
  1. LIVE     : the current feed (300 URLs, refreshed every ~6-12 h)
  2. HISTORY  : every past snapshot of the feed from the public GitHub
                repository openphish/public_feed (2 commits/day since Oct 2024),
                which gives every URL a first-seen / last-seen date.

Run it once with --history to backfill, then once a day (any time) to keep the
live side growing. Every run appends one line to collection_log.csv.

Usage
    python collect_phish.py --history --since 2026-06-01     # backfill (a few minutes)
    python collect_phish.py                                   # daily live pull (seconds)
    python collect_phish.py --out data/                       # choose output folder

Outputs (in --out, default ./data)
    phish_urls.csv        url, first_seen, last_seen, n_snapshots, source
    collection_log.csv    run_time, mode, snapshots_read, urls_fetched, urls_new, note

Requirements: Python 3.9+, git on PATH, `pip install requests`
"""
import argparse, csv, os, subprocess, sys, datetime as dt, shutil, tempfile

LIVE_URLS = [
    "https://raw.githubusercontent.com/openphish/public_feed/main/feed.txt",
    "https://openphish.com/feed.txt",
]
REPO = "https://github.com/openphish/public_feed"


def now():
    return dt.datetime.now(dt.timezone.utc).strftime("%Y-%m-%dT%H:%M:%SZ")


def load_existing(path):
    rows = {}
    if os.path.exists(path):
        with open(path, newline="", encoding="utf-8") as f:
            for r in csv.DictReader(f):
                rows[r["url"]] = r
    return rows


def save(path, rows):
    with open(path, "w", newline="", encoding="utf-8") as f:
        w = csv.DictWriter(f, fieldnames=["url", "first_seen", "last_seen", "n_snapshots", "source"])
        w.writeheader()
        for u in sorted(rows, key=lambda k: rows[k]["first_seen"]):
            w.writerow(rows[u])


def merge(rows, urls, seen_at, source):
    new = 0
    for u in urls:
        u = u.strip()
        if not u or u.startswith("#"):
            continue
        if u in rows:
            r = rows[u]
            r["first_seen"] = min(r["first_seen"], seen_at)
            r["last_seen"] = max(r["last_seen"], seen_at)
            r["n_snapshots"] = str(int(r["n_snapshots"]) + 1)
        else:
            rows[u] = {"url": u, "first_seen": seen_at, "last_seen": seen_at, "n_snapshots": "1", "source": source}
            new += 1
    return new


def fetch_live():
    import requests
    for src in LIVE_URLS:
        try:
            r = requests.get(src, timeout=30, headers={"User-Agent": "CSCI-U550-student-project/1.0"})
            if r.status_code == 200 and r.text.strip():
                return r.text.splitlines(), src
        except Exception as e:  # noqa
            print(f"  {src}: {e}", file=sys.stderr)
    raise SystemExit("could not fetch the live feed from any source")


def fetch_history(since):
    """Yield (date, urls) for every commit since `since` (YYYY-MM-DD)."""
    tmp = tempfile.mkdtemp(prefix="openphish_")
    try:
        print(f"  cloning {REPO} (metadata only) ...")
        subprocess.run(["git", "clone", "-q", "--filter=blob:none", REPO, tmp], check=True)
        log = subprocess.run(["git", "-C", tmp, "log", "--reverse", f"--since={since}", "--format=%H %cI"],
                             capture_output=True, text=True, check=True).stdout.split("\n")
        commits = [l.split() for l in log if l.strip()]
        print(f"  {len(commits)} snapshots since {since}")
        for i, (h, date) in enumerate(commits, 1):
            txt = subprocess.run(["git", "-C", tmp, "show", f"{h}:feed.txt"], capture_output=True, text=True).stdout
            yield date[:19].replace("+00:00", "") + "Z" if date.endswith("+00:00") else date, txt.splitlines()
            if i % 100 == 0:
                print(f"  {i}/{len(commits)}", end="\r", flush=True)
        print()
    finally:
        shutil.rmtree(tmp, ignore_errors=True)


def main():
    ap = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("--out", default="data")
    ap.add_argument("--history", action="store_true", help="also read past snapshots from GitHub")
    ap.add_argument("--since", default=(dt.date.today() - dt.timedelta(days=120)).isoformat(),
                    help="earliest snapshot date for --history (default: 120 days ago)")
    a = ap.parse_args()
    os.makedirs(a.out, exist_ok=True)
    out_csv, log_csv = os.path.join(a.out, "phish_urls.csv"), os.path.join(a.out, "collection_log.csv")
    rows = load_existing(out_csv)
    before = len(rows)

    if a.history:
        print("HISTORY mode")
        n_snap, n_fetched = 0, 0
        for date, urls in fetch_history(a.since):
            n_snap += 1; n_fetched += len(urls)
            merge(rows, urls, date, "openphish-history")
        log_line = [now(), "history", n_snap, n_fetched, len(rows) - before, f"since={a.since}"]
        print(f"  {n_snap} snapshots, {n_fetched} URLs read, {len(rows) - before} new unique URLs")
    else:
        print("LIVE mode")
        urls, src = fetch_live()
        new = merge(rows, urls, now(), "openphish-live")
        log_line = [now(), "live", 1, len(urls), new, src]
        print(f"  fetched {len(urls)} URLs from {src}, {new} new")

    save(out_csv, rows)
    write_header = not os.path.exists(log_csv)
    with open(log_csv, "a", newline="", encoding="utf-8") as f:
        w = csv.writer(f)
        if write_header:
            w.writerow(["run_time", "mode", "snapshots_read", "urls_fetched", "urls_new", "note"])
        w.writerow(log_line)
    print(f"  total unique phishing URLs: {len(rows)}  ->  {out_csv}")
    print(f"  log appended             ->  {log_csv}")


if __name__ == "__main__":
    main()
