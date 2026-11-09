using CapstoneProject.Data;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CapstoneProject.Areas.Identity.Data;


namespace CapstoneProject.Controllers
{
    public class RegistrationController : Controller
    {
        // The private readonly field that holds the instance of the ApplicationDbContext
        private readonly CapstoneProjectDbContext _db;
        private readonly UserManager<CapstoneProjectUser> _userManager;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(CapstoneProjectDbContext db, ILogger<RegistrationController> logger, UserManager<CapstoneProjectUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> LiabilityForm()
        {
            var user = await _userManager.GetUserAsync(User);


            Liability form = new()
            {
                FirstName = user.FirstName,
                MidName = "",
                LastName = user.LastName,
                UserID = user.StudentId,
            };


            return View(form);
        }
        [Authorize]
        public async Task<IActionResult> UserApplicationForm()
        {
            var user = await _userManager.GetUserAsync(User);




            return View(user);
        }

        //Submits data
        [HttpPost, ActionName("UserApplicationForm")]
        public async Task<IActionResult> UserApplicationFormPOST(CapstoneProjectUser obj)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null || user.StudentId != obj.StudentId) return BadRequest();

                user.AttendsCherokee = obj.AttendsCherokee;
                user.AttendsDowntown = obj.AttendsDowntown;
                user.AttendsSpartanburg = obj.AttendsSpartanburg;
                user.AttendsTygerRiver = obj.AttendsTygerRiver;
                user.AttendsUnion = obj.AttendsUnion;
                user.DOB = obj.DOB;
                user.Employed = obj.Employed;
                user.EmployedHouseMembers = obj.EmployedHouseMembers;
                user.EthAfricanAmerican = obj.EthAfricanAmerican;
                user.EthAsian = obj.EthAsian;
                user.EthCaucasian = obj.EthCaucasian;
                user.EthLatino = obj.EthLatino;
                user.EthMiddleEastern = obj.EthMiddleEastern;
                user.EthNativeAmerican = obj.EthNativeAmerican;
                user.EthOther = obj.EthOther;
                user.EthPacificIslander = obj.EthPacificIslander;
                user.FirstName = obj.FirstName;
                user.LastName = obj.LastName;
                user.Gender = obj.Gender;
                user.HasSNAP = obj.HasSNAP;
                user.HasTANF = obj.HasTANF;
                user.HasTransportation = obj.HasTransportation;
                user.HasWIC = obj.HasWIC;
                user.HouseholdAdults = obj.HouseholdAdults;
                user.HouseholdBabiesChildren = obj.HouseholdBabiesChildren;
                user.HouseholdBabiesToddlers = obj.HouseholdBabiesToddlers;
                user.HouseholdTeens = obj.HouseholdTeens;   
                user.IsInterestedInSNAP = obj.IsInterestedInSNAP;
                user.IsInterestedInTANF = obj.IsInterestedInTANF;
                user.IsInterestedInWIC = obj.IsInterestedInWIC;
                user.IsRegistrationComplete = true;
                user.PhoneNum = obj.PhoneNum;
                user.StudentStatus = obj.StudentStatus;
                user.PhoneNumber = user.PhoneNum;


                user.MaxPoints = 40 + 20 * (obj.HouseholdBabiesChildren + obj.HouseholdBabiesToddlers + obj.HouseholdTeens + obj.HouseholdAdults);
                user.Points = user.MaxPoints;
                user.IsRegistrationComplete = true;
                _db.Update(user);
                    
                _db.SaveChanges(); // save changes
                TempData["success"] = "User created successfully";
                return RedirectToAction("LiabilityForm", "Registration");
            }
            return View(obj);
            
        }

        [HttpPost, ActionName("LiabilityForm")]
        public IActionResult LiabilityFormPOST(Liability obj)
        {
            if (ModelState.IsValid)
            {
                DateTime date = DateTime.Now;
                obj.Date = DateOnly.FromDateTime(date);

                obj.RenewalDate = obj.Date.AddYears(1);


                _db.LiabilityForms.Add(obj);
                _db.SaveChanges();

                TempData["success"] = "Liability Form created successfully";
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        public IActionResult WelcomePageView()
        {
            return View();
        }

        public IActionResult RulesForm()
        {
            return View();
        }
    }
}
