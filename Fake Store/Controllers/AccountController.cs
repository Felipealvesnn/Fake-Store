using Fake_Store.Models;
using Fake_Store_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fake_Store.Controllers
{

    public class AccountController : Controller
    {

        private readonly IAuthenticate _authentication;

        public AccountController(IAuthenticate authenticate)
        {
            _authentication = authenticate;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var result = await _authentication.Authenticate(loginVM.Email, loginVM.Password);
            

            if (result)
            {
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(loginVM.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return View(loginVM);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginVM model)
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");

                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.logout();
            return Redirect("/Account/Login");
        }
    }
}
