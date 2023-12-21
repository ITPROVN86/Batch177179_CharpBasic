using Microsoft.AspNetCore.Mvc;

namespace WebDemo14112023.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
