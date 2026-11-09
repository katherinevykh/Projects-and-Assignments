using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin, Staff, Student")]
    public class UpdateLiabilityFormController : Controller
    {
        private readonly CapstoneProjectDbContext _db;

        public UpdateLiabilityFormController(CapstoneProjectDbContext db)
        {
            _db = db;
        }

        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Liability obj)
        {
            if (ModelState.IsValid)
            {
                //Retrieve the existing records off user id
                var existingLiability = _db.LiabilityForms.FirstOrDefault(l => l.UserID == obj.UserID);

                if (existingLiability != null)
                {
                    //Update existing records
                    existingLiability.Date = obj.Date;
                    existingLiability.RenewalDate = obj.RenewalDate;
                    existingLiability.FirstName = obj.FirstName;
                    existingLiability.MidName = obj.MidName;
                    existingLiability.LastName = obj.LastName;

                    //Set RenewalDate to one year from now
                    existingLiability.RenewalDate = obj.Date.AddYears(1);

                    
                    _db.LiabilityForms.Update(existingLiability);
                    _db.SaveChanges();

                    TempData["success"] = "Item updated successfully";
                }
                

                return RedirectToAction("UpdateLiabilityForm", "Staff");
            }

            return View();
        }
    }
}