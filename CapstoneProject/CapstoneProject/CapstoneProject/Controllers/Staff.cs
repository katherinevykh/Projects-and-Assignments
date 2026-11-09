using CapstoneProject.Areas.Identity.Data;
using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class Staff : Controller
    {
        // The private readonly field that holds the instance of the ApplicationDbContext
        private readonly CapstoneProjectDbContext _db;
        private readonly ILogger<Staff> _logger;
        private readonly UserManager<CapstoneProjectUser> _userManager;

        public Staff(CapstoneProjectDbContext db, ILogger<Staff> logger, UserManager<CapstoneProjectUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult EndOfSemesterEvaluation()
        {
            return View();
        }

        [HttpGet]
        [Route("Staff/DonationForm")]
        public IActionResult DonationForm()
        {
            return View();
        }

        [HttpPost]
        [Route("Staff/DonationForm")]
        public IActionResult DonationForm(Donation Donation)
        {
            // set the date
            Donation.Date = DateOnly.FromDateTime(DateTime.Now);

            ModelState.Remove(nameof(Donation.DonationID));

            if (ModelState.IsValid)
            {
                try
                {
                    // add the donation to the database context
                    _db.Donations.Add(Donation);

                    // save changes to the database
                    _db.SaveChanges();

                    // redirect to the same form
                    TempData["success"] = "Donation created successfully";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the donation. Exception: {ExceptionMessage}", ex.Message);
                    ModelState.AddModelError("", "An error occurred while saving the donation. Please try again.");
                }
            }
            else
            {
                LogModelStateErrors();
            }
            return View(Donation);
        }

        private void LogModelStateErrors()
        {
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogError("Validation error in field '{Field}': {ErrorMessage}", state.Key, error.ErrorMessage);
                }
            }
        }

        //Pulls up form
        public IActionResult RequestForm()
        {
            return View();
        }

        //Submits data
        [HttpPost, ActionName("RequestForm")]
        public IActionResult RequestFormPOST(ResourceRequest obj)
        {
            if (_db.Users.Any(user => user.StudentId == obj.UserID))
            {

                if (ModelState.IsValid)
                {
                    DateTime date = DateTime.Now;
                    obj.Date = DateOnly.FromDateTime(date);


                    _db.ResourceRequests.Add(obj); // update item 
                    _db.SaveChanges(); // save changes
                    TempData["success"] = "Request created successfully";
                    return RedirectToAction("Index", "Home");
                }
                return View(obj);
            }
            else
            {
                TempData["error"] = "User Id does not exist.";
                return RedirectToAction("RequestForm", "Staff");

            }

        }

        public IActionResult UpdateLiabilityForm()
        {
            return View();
        }


        //Submits data
        [HttpPost, ActionName("PurchaseForm")]
        public IActionResult PurchaseFormPOST(Purchasing obj)
        {
            if (ModelState.IsValid)
            {
                _db.Purchases.Add(obj); // update item 
                _db.SaveChanges(); // save changes
                TempData["success"] = "Purchase created successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        public IActionResult PurchaseForm()
        {
            return View();
        }

        public IActionResult ViewRequests(int pg)
        {
            ViewBag.pgMax = _db.Transactions.Count() / 25;

            if (pg == null || pg < 0)
            {
                pg = 0;
            }
            else if (pg > ViewBag.pgMax)
            {
                pg = ViewBag.pgMax;
            }
            var requests = _db.Transactions.OrderBy(x => x.IsProcessed).ThenBy(x => x.Date).Skip(25 * pg).Take(25).ToList();

            ViewBag.pg = pg;

            return View(requests);
        }

        public IActionResult ViewRequest(int id)
        {
            try
            {
                var model = _db.Transactions.Where(x => x.TransactionID == id).Include(x => x.LineItems).ThenInclude(x => x.Item).SingleOrDefault();
                if (model == null) return NotFound();

                var user = _db.Users.Where(x => x.StudentId == model.UserID).SingleOrDefault();

                ViewBag.email = user?.Email ?? "User does not exist in the database.";
                ViewBag.points = user?.Points.ToString() ?? "N/A";
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult ProcessRequest([FromBody] RequestProcessDTO transactionDto)
        {
            try
            {
                if (transactionDto.AdditionalPoints < 0) return BadRequest();

                var transaction = _db.Transactions.Where(x => x.TransactionID == transactionDto.TransactionID)
                    .Include(x => x.LineItems).ThenInclude(x => x.Item).SingleOrDefault();
                if (transaction == null) return NotFound();

                

                var user = _db.Users.Where(x => x.StudentId == transaction.UserID).SingleOrDefault();
                string email = "";
                string body = "";

                using (var dbTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        if (user != null)
                        {
                            email = user.Email;
                            body = "Hello,\n\nYour request has been approved. Any modifications made are listed below:\n\n";
                            int points = 0;

                            foreach (var line in transaction.LineItems)
                            {
                                int requested = transactionDto.Items[line.ItemID];
                                if (requested > line.Item.Quantity)
                                {
                                    throw new Exception($"Requested more of {line.Item.Description} than available");
                                }
                                else if (requested < 0)
                                {
                                    throw new Exception($"Requested negative amount of {line.Item.Description}");
                                }

                                if (line.Quantity != requested)
                                {
                                    body += $"{line.Item.Description}:\n\tRequested: {(int)line.Quantity}\n\tReceived: {requested}\n\n";
                                }
                                line.Item.Quantity -= requested;
                                _db.Update(line.Item);
                                points += requested * line.Item.PointCost;

                            }
                            if (points + transactionDto.AdditionalPoints > user.Points)
                            {
                                throw new Exception($"The user does not have enough points.\nAvailable: {user.Points}\nNeeded: {points}");
                            }


                            user.Points -= points + transactionDto.AdditionalPoints;
                            _db.Update(user);

                            transaction.IsProcessed = true;
                            transaction.AdditionalPointCost = transactionDto.AdditionalPoints;
                            _db.Update(transaction);

                            _db.SaveChanges();
                            dbTransaction.Commit();
                        }
                        else
                        {
                            foreach (var line in transaction.LineItems)
                            {
                                int requested = transactionDto.Items[line.ItemID];
                                if (requested > line.Item.Quantity)
                                {
                                    throw new Exception($"Requested more of '{line.Item.Description}' than available");
                                }
                                else if (requested < 0)
                                {
                                    throw new Exception($"Requested negative amount of '{line.Item.Description}'.");
                                }
                                line.Item.Quantity -= requested;
                                _db.Update(line.Item);

                            }

                            transaction.IsProcessed = true;
                            _db.Update(transaction);
                            _db.SaveChanges();
                            dbTransaction.Commit();

                        }
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return BadRequest(ex.Message);
                    }
                    return Json(new { email = email, body = body });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RejectRequest([FromBody] RequestProcessDTO transactionDto)
        {
            try
            {
                var transaction = _db.Transactions.Where(x => x.TransactionID == transactionDto.TransactionID)
                    .Include(x => x.LineItems).ThenInclude(x => x.Item).SingleOrDefault();
                if (transaction == null) return NotFound();


                var user = _db.Users.Find(transaction.UserID);
                string email = "";
                string body = "";

                using (var dbTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        if (user != null)
                        {
                            email = user.Email;
                            body = "Hello,\n\nYour request has been rejected.\n\n{ADD NOTES HERE}";
                        }
                        transaction.IsProcessed = true;
                        _db.Update(transaction);
                        _db.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        return BadRequest(ex.Message);
                    }

                    return Json(new { email = email, body = body });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public IActionResult FindUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var user = _db.Users.Where(x => x.StudentId == userId).FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return RedirectToAction("UserDetails", user);
        }


        public IActionResult UserDetails(CapstoneProjectUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var roleIds = _db.UserRoles.Where(x => x.UserId == user.Id).Select(x=>x.RoleId);
            var roles = _db.Roles.Where(x => roleIds.Contains(x.Id)).Select(x=>x.NormalizedName);

            var model = new UserDetailsGetDTO()
            {
                User = user,
                IsAdmin = roles.Contains("ADMIN"),
                IsStaff = roles.Contains("STAFF")
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserDetailsPostDTO dto)
        {
            if(dto.Points < 0 && dto.MaxPoints < 0) return BadRequest();

            var user = _db.Users.Where(x=>x.StudentId == dto.UserID).FirstOrDefault();

            if(user == null) return NotFound();

            user.Points = dto.Points;
            user.MaxPoints = dto.MaxPoints;

            if(dto.IsAdmin.HasValue)
            {
                if (dto.IsAdmin.Value)
                {
                    if (!await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        await _userManager.RemoveFromRoleAsync(user, "Admin");
                    }
                }
            }

            if (dto.IsStaff.HasValue)
            {
                if (dto.IsStaff.Value)
                {
                    if (!await _userManager.IsInRoleAsync(user, "Staff"))
                    {
                        await _userManager.AddToRoleAsync(user, "Staff");
                    }
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, "Staff"))
                    {
                        await _userManager.RemoveFromRoleAsync(user, "Staff");
                    }
                }
            }

            _db.Update(user);
            _db.SaveChanges();
            return Ok();
        }
    }
}
