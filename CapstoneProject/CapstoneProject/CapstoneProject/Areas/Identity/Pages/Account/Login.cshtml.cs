using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Areas.Identity.Data;

namespace CapstoneProject.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<CapstoneProjectUser> _signInManager;
        private readonly UserManager<CapstoneProjectUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<CapstoneProjectUser> signInManager, UserManager<CapstoneProjectUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Student ID")]
            public string StudentId { get; set; }

            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // Find user by StudentId
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.StudentId == Input.StudentId);
                if (user != null)
                {

                    //await _signInManager.SignInAsync(user, isPersistent: Input.RememberMe);
                    await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, false);
                    _logger.LogInformation("User logged in with Student ID.");
                    return LocalRedirect(returnUrl);
                    
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt. Student ID not found.");
                return Page();
            }

            return Page();
        }
    }
}