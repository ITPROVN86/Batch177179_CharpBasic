using AutomobileLibrary.DataAccess;
using AutomobileLibrary.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileWebApp.Controllers
{
    public class CarsController : Controller
    {
        ICarRepository carRepository = null;
        public CarsController()
        {
            carRepository= new CarRepository();
        }
        // GET: CarsController
        public ActionResult Index()
        {
            var list = carRepository.GetCars();
            return View(list);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCardByID(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    carRepository.Add(c);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(c);
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCardByID(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car c)
        {
            try
            {
                if (id != c.CarId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    carRepository.Update(c);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(c);
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carRepository.GetCardByID(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car c)
        {
            try
            {
                var car = carRepository.GetCardByID(id);
                carRepository.Delete(car);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(c);
            }
        }
    }
}
