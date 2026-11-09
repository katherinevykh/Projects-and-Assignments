import pandas as pd
import matplotlib.pyplot as plt

df = pd.read_csv("final_curated_dataset.csv")

#benign = pd.read_csv("benign_urls.csv")
#phish = pd.read_csv("data/phish_urls.csv")

'''
print("Legitimate URLs:", len(benign))
print("Phishing URLs:", len(phish))
print(benign.head())
print(phish.head())
'''
print("Total URls: ", len(df))
print(df["label"].value_counts())
print(df.head())


#cleaned URL
df["clean_url"] = df["model_clean_url"].astype(str)

df["label_numeric"] = df["label"].map({
    "legitimate": 0,
    "phishing": 1,
})

print(df.head())


# CREATE FEATURES FOR GRAPHS

df["url_length"] = df["clean_url"].str.len()
df["dots"] = df["clean_url"].str.count(r"\.")
df["digits"] = df["clean_url"].str.count(r"\d")
df["hyphens"] = df["clean_url"].str.count("-")
df["at_symbols"] = df["clean_url"].str.count("@")
df["has_ip"] = df["clean_url"].str.contains(r"^(?:\d{1,3}\.){3}\d{1,3}(?=[:/]|$)",regex=True).astype(int)

# Create URL length

df["url_length"] = df["clean_url"].str.len()

# GRAPH 1: URL Lengths
plt.figure(figsize=(8, 5))
#df[df["label"] == 0]["url_length"].hist(bins=50, alpha=0.5, label="legitimate" )
#df[df["label"] == 1]["url_length"].hist(bins=50, alpha=0.5, label="Phishing")

df[df["label_numeric"] == 0]["url_length"].hist(
    bins=50,
    alpha=0.5,
    label="Legitimate"
)

df[df["label_numeric"] == 1]["url_length"].hist(
    bins=50,
    alpha=0.5,
    label="Phishing"
)

plt.xlabel("URL Length")
plt.ylabel("Number of URLs")
plt.title("URL Length: Phishing vs Legitimate")
plt.legend()
plt.show()

# *********** INTERPRETATION OF FIGURE #1 ************
# This graph compares the lengths of legitimate and phishing URLs. The URL length is an important feature because
# phishing websites sometimes use longer URLs to include false/misleading information and additional directories.
# This graph shows how URL lengths are distributed across both classes, allowing us compare their typical lengths and
# identify unusually long URLs. If phishing URLs are generally longer than legitimate URLs, this could indicate that URL
# length is useful for detecting suspicious websites.

# GRAPH 2:  @ SYMBOLS
df["at_symbols"] = df["clean_url"].str.count("@")
plt.figure(figsize=(6, 5))
df.groupby("label")["at_symbols"].mean().plot(kind="bar")
plt.xlabel("")
plt.ylabel("Average Number of @ Symbols")
plt.title("@ Symbols in URLs")
plt.xticks([0, 1], ["Legitimate", "Phishing"], rotation=0)
plt.show()

# *********** INTERPRETATION OF FIGURE #2 ************
# This graph compares the average number of @ symbols found in legitimate and phishing URLs. The @ symbol is can be used
# in a URL to separate user information from the actual website address and attackers may take advantage of this by placing
# a trusted looking website name before the @ symbol while directing users to a different destination. This graph measures
# how frequently this character appears in each class. If phishing URLs have a higher average, this would suggest that
# the @ symbol is a useful warning sign. This feature works best when compared alongside other suspicious URL characteristics.

# GRAPH 3: IP ADDRESS
plt.figure(figsize=(6, 5))
(df.groupby("label")["has_ip"].mean() * 100).plot(kind="bar")
plt.xlabel("")
plt.ylabel("URLs Using IP Address (%)")
plt.title("IP Address Usage")
plt.xticks([0, 1], ["Legitimate", "Phishing"], rotation=0)
plt.show()

# *********** INTERPRETATION OF FIGURE #3 ************
# This graph compares the percentage of legitimate and phishing URLs that use an IP address instead of a
# traditional domain name. Most websites use domain names, meanwhile some suspicious websites may use numerical IP addresses
# to direct users somewhere else. The graph calculates the percentage of URLs in each class that begin with an IPv4-style
# address. If phishing URLs have a higher percentage, it could indicate that IP address usage is a useful feature for
# identifying potential phishing attacks.

# GRAPH 4: # OF DIGITS
plt.figure(figsize=(6, 5))
df.groupby("label")["digits"].mean().plot(kind="bar")
plt.xlabel("")
plt.ylabel("Average Number of Digits")
plt.title("Digits in URLs")
plt.xticks([0, 1], ["Legitimate", "Phishing"], rotation=0)
plt.show()

# *********** INTERPRETATION OF FIGURE #4 ************
# This graph compares the average number of numerical digits found in legitimate and phishing URLs. Digits are useful to
# examine because phishing URLs may contain random numbers, identification codes, or automatically generated strings.
# Which can make URLs more complicated and harder for users to recognize. The graph calculates the average number of digits
# for each class, making it possible to see whether one group uses more numbers than the other. A higher number among
# phishing URLs could suggest that numerical characters help distinguish phishing websites.

# GRAPH 5: # OF HYPHENS
plt.figure(figsize=(6, 5))
df.groupby("label")["hyphens"].mean().plot(kind="bar")
plt.xlabel("")
plt.ylabel("Average Number of Hyphens")
plt.title("Hyphens in URLs")
plt.xticks([0, 1], ["Legitimate", "Phishing"], rotation=0)
plt.show()

# *********** INTERPRETATION OF FIGURE #5 ************
# This graph compares the average number of hyphens found in legitimate and phishing URLs. Hyphens are commonly used in
# website addresses to separate words and make URLs easier to read. So phishing websites may also use hyphens to create
# domain names that resemble legitimate website names. Attackers use this to make fraudulent websites look trustworthy.
# The graph measures whether hyphens are more common in one class than the other. If phishing URLs have a higher average,
# this could suggest that hyphen usage is a helpful feature for detecting phishing URLs.

# GRAPH 6: # OF DOTS
plt.figure(figsize=(6, 5))
df.groupby("label")["dots"].mean().plot(kind="bar")
plt.xlabel("")
plt.ylabel("Average Number of Dots")
plt.title("Average Number of Dots")
plt.xticks([0, 1], ["Legitimate", "Phishing"], rotation=0)
plt.show()

# *********** INTERPRETATION OF FIGURE #6 ************
# This graph compares the average number of dots found in legitimate and phishing URLs. Dots are important because they
# separate different parts of a domain name and may also appear in URL paths or file extensions. Phishing websites sometimes
# use multiple subdomains to make a URL appear connected to a trusted organization.The graph calculates the average number
# of dots in each class to determine whether one group has more complex URL structures. If phishing URLs contain more dots
# on average, this could suggest that attackers use additional subdomains or other URL components to disguise malicious websites



#Additional graph 7 - analysis of change overtime

# Select only phishing URLs from the final combined dataset
phish_df = df[df["label"] == "phishing"].copy()

# Convert the timestamp column to datetime
phish_df["timestamp"] = pd.to_datetime(
    phish_df["timestamp"],
    errors="coerce"
)

# Count phishing URLs by the date they were first seen
daily_counts = (
    phish_df
    .dropna(subset=["timestamp"])
    .groupby(phish_df["timestamp"].dt.date)
    .size()
)

# Create the graph
plt.figure(figsize=(9, 5))

daily_counts.plot(
    kind="line",
    marker="o"
)

# GRAPH 7: # PHISHING URLS OVER TIME
plt.xlabel("Date")
plt.ylabel("Number of Phishing URLs")
plt.title("Phishing URLs First Seen Over Time")
plt.xticks(rotation=45)
plt.tight_layout()
plt.show()

# *********** INTERPRETATION OF FIGURE #7 ************
# This graph shows how the number of phishing URLs first observed in the dataset
# changes over time. This is important because phishing websites are constantly
# being created and modified as attackers try to avoid detection. By looking at
# the dates when phishing URLs were first recorded, we can examine how the number
# of newly observed URLs varies throughout the collection period. For security
# analysts, this information is useful because it can help identify periods of
# increased phishing URL discovery and show why detection systems need to be
# regularly updated.