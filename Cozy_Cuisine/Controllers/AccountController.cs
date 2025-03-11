using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Cozy_Cuisine.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Error"] = "Invalid email or password.";
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                TempData["Success"] = "Login successful! Welcome back.";
                return RedirectToAction("Index", "Home"); // Redirect to homepage or dashboard
            }

            TempData["Error"] = "Invalid login attempt.";
            return View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
