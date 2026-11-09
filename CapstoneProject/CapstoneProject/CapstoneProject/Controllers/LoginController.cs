//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using CapstoneProject.Data;
//using CapstoneProject.Models;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Authorization;

//namespace CapstoneProject.Controllers
//{
//    public class LoginController : Controller
//    {
//        private readonly ApplicationDbContext _db;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public LoginController(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
//        {
//            _db = db;
//            _httpContextAccessor = httpContextAccessor;
//        }


//        [HttpGet]
//        public IActionResult Login()
//        {
//            if (User.Identity.IsAuthenticated)
//            {
//                return RedirectToAction("Index", "Home");
//            }
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login( StaffSignIn obj)
//        {
//            if (ModelState.IsValid)
//            {
//                StaffRegister userFromDb = _db.StaffUsers.Find(obj.UserID);
//                if (userFromDb != null)
//                {
//                    if (userFromDb.Password == obj.Password)
//                    {
//                        var claims = new List<Claim>
//                        {
//                            new Claim(ClaimTypes.NameIdentifier, userFromDb.UserID),
//                            new Claim(ClaimTypes.Name, userFromDb.UserID)
//                        };

//                        var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
//                        var authProperties = new AuthenticationProperties
//                        {
//                            IsPersistent = false
//                        };

//                        await _httpContextAccessor.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

//                        return RedirectToAction("Index", "Home");
//                    }
//                    else
//                    {
//                        ViewBag.ErrorMessage = "Invalid Password";
//                        return View();
//                    }
//                }
//                else
//                {
//                    ViewBag.ErrorMessage = "Invalid User ID";
//                    return View();
//                }
//            }
//            return View();

//        }

//        public async Task<IActionResult> Logout()
//        {
//            await _httpContextAccessor.HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
//            return RedirectToAction("Login");
//        }

//        public IActionResult SignUp()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult SignUp(StaffRegister obj)
//        {
//            if (ModelState.IsValid)
//            {
//                var existingUser = _db.StaffUsers.FirstOrDefault(u => u.UserID == obj.UserID);
//                if (existingUser != null)
//                {
//                    ViewBag.ErrorMessage = "Account already registered";
//                    return View();
//                }

//                _db.StaffUsers.Add(obj);
//                _db.SaveChanges();
//                TempData["success"] = "User created successfully";
//                return RedirectToAction("Login");

//            }
//            return View();
//        }
//    }
//}