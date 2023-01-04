using Microsoft.AspNetCore.Mvc;

namespace Fake_Store.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
