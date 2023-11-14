using Microsoft.AspNetCore.Mvc;
using WebDemo14112023.Models;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (model.UserName.Contains("admin") && model.Password.Contains("admin"))
            {
                TempData["Info"] = "Admin";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
