using CapstoneProject.Data;
using CapstoneProject.Models;
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CapstoneProject.ViewModels;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using CapstoneProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin, Staff, Student, Volunteer")]
    public class UserController : Controller
    {
        private readonly CapstoneProjectDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<CapstoneProjectUser> _userManager;

        public UserController(CapstoneProjectDbContext db, ILogger<UserController> logger, UserManager<CapstoneProjectUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin,Staff")]
        public IActionResult FindUser()
        {
            return View();
        }
        [HttpPost, ActionName("FindUser")]
        [Authorize(Roles = "Admin,Staff")]
        public IActionResult FindUserPost(string userId)
        {
            var user = _db.Users.Where(x=>x.StudentId == userId).SingleOrDefault();
            if (user != null)
            {
                string username = user.FirstName + " " + user.LastName;
                return RedirectToAction("AidForm", new { username = username, userID = userId });
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> AidForm(string username, string userID)
        {

            CapstoneProjectUser user;
            if(string.IsNullOrWhiteSpace(userID)) 
            {
                user = await _userManager.GetUserAsync(User);
                if(user != null)
                {
                    bool isStudent = await _userManager.IsInRoleAsync(user, "student");
                    if(!isStudent)
                    {
                        return View("FindUser");
                    }
                }
            }
            else
            {
                user = _db.Users.Where(x => x.StudentId == userID).SingleOrDefault();
            }
            if (user == null)
            {
                return BadRequest();
            }

            if (user.IsRegistrationComplete)
            {
                ViewBag.Username = $"{user.FirstName} {user.LastName}";
                ViewBag.UserID = user.StudentId;
                ViewBag.Points = user.Points;

                return View();
            }
            else
            {
                return RedirectToAction("WelcomePageView", "Registration");
            }
            
        }

        public JsonResult PopulateItemDropdown(int subcategoryID)
        {
            return Json(_db.Items.Where(x => x.SubcategoryID == subcategoryID).ToList());
        }



        public JsonResult PopulateSubcategoryDropdown(int category)
        {
            var res = Json(_db.ItemSubcategories.Where(x => x.CategoryID == category).ToList());
            return res;
        }

        public JsonResult PopulateCategoryDropdown()
        {
            var res = Json(_db.ItemCategories.ToList());
            return res;
        }

        public JsonResult GetItemByItemID(Int32 itemID)
        {
            var results = Json(_db.Items.Where(u => u.ItemID == itemID));

            return results;
        }


        [HttpPost]
        public IActionResult AidForm()
        {
            
            TempData["success"] = "Transaction created successfully";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> PostTransaction([FromBody] CartList cartList)
        {
            if (cartList == null)
                return BadRequest();

            var user = _db.Users.Where(x => x.StudentId == cartList.UserID).SingleOrDefault();

            if (user == null) return BadRequest();

            Transaction transactionobj = new Transaction { UserID = user.StudentId, SpecialRequests = cartList.SpecialRequests.Trim() };

            if (ModelState.IsValid)
            {
                //begin a transaction (allows rollback of changes if something goes wrong half-way through)
                using (var dbTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.Transactions.Add(transactionobj);

                        _db.SaveChanges();

                        foreach (var cartItem in cartList.cartList)
                        {
                            //create a line item for every cart item
                            TransactionLineItem line = new TransactionLineItem()
                            {
                                TransactionID = transactionobj.TransactionID,
                                ItemID = cartItem.Item.ItemID,
                                Quantity = cartItem.Info.QuantityReq,
                                IsPAL = cartItem.Info.IsPal,
                                IsRG = cartItem.Info.IsRG,
                            };

                            //add it to the table
                            _db.TransactionLineItems.Add(line);

                        }

                        //save the changes and commit
                        _db.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        _logger.LogError("Unable to complete transaction");
                        TempData["success"] = "Failed to create item";
                        return BadRequest();
                    }

                }
                TempData["success"] = "Item created successfully";

                return Ok();
            }
            TempData["success"] = "Item data invalid";
            return BadRequest();
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

    }
}

    //[HttpPost]
    //public int PostTransaction([FromBody] TransactionDTO transaction)
    //{

    //    //String user = transaction.UserID;

    //    //var date = DateOnly.FromDateTime(DateTime.Now);

    //    //Transaction transactionobj = new Transaction() { UserID = user, Date = date };

    //    //if (ModelState.IsValid)
    //    //{
    //    //    _db.Transactions.Add(transactionobj);
    //    //    _db.SaveChanges();
    //    //    TempData["success"] = "Item created successfully";

    //    //    return ;
    //    //}
    //    //return View();
    //}
