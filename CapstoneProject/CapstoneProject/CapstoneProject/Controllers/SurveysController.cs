using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    [Authorize(Roles = "Admin, Staff, Student")]
    public class SurveysController : Controller
    {
        public IActionResult FacSurvey()
        {
            return View();
        }

        public IActionResult UserSurvey()
        {
            return View();
        }
    }
}
