using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Cozy_Cuisine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Cozy_Cuisine.Models;
using Microsoft.EntityFrameworkCore;
using Cozy_Cuisine.Data;

namespace Cozy_Cuisine.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
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
                return RedirectToAction("Login", "Account"); // Redirect to homepage or dashboard
            }

            TempData["Error"] = "Invalid login attempt.";
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Success"] = "Logout successful! Come Back Later";
            return RedirectToAction("Login", "Account");
        }


    }
}
