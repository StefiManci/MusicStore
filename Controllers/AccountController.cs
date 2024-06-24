using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MusicStore.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AppUser user=await userManager.FindByEmailAsync(details.Email);
                if (user!=null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ??"/");
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Email),
 "Invalid user or password");
            }
            return View(details);
        }
        [HttpPost]
        public async Task<RedirectResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
