using Microsoft.AspNetCore.Mvc;
using MyCodeFirstApproachDemo.Models;

namespace MyCodeFirstApproachDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee em)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Success!";
                ViewData["alert"] = "alert-danger";
                ViewBag.alert = "alert-danger";
                ViewBag.Message = "Success!";
            }
            return RedirectToAction(nameof(Index));
            //return View(nameof(Index));
        }
    }
}
