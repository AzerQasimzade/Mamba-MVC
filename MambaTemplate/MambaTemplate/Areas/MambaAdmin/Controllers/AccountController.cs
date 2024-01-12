using MambaTemplate.Areas.MambaAdmin.ViewModels;
using MambaTemplate.DAL;
using MambaTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MambaTemplate.Areas.MambaAdmin.Controllers
{
    [Area("MambaAdmin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser
            {
                UserName = userVM.UserName,
                Email = userVM.Email,
                Country = userVM.Country
            };
            IdentityResult identityResult= await _userManager.CreateAsync(user,userVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError(String.Empty, item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)return View();
            AppUser existedUser = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if (existedUser is null)
            {
                existedUser = await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
                if(existedUser is null)
                {
                    ModelState.AddModelError(String.Empty, "Bele istifadeci yoxdur");
                    return View();
                }
            }
            var passwordResult = await _signInManager.PasswordSignInAsync(existedUser, loginVM.Password, loginVM.IsRemembered, true);
            if (passwordResult.IsLockedOut)
            {
                ModelState.AddModelError(String.Empty, "You have blocked");
                return View();
            }
            if (!passwordResult.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username or Password is incorrect");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
