using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsCategoryController : BaseController
    {
        IProductsCategoryRepository productsCategoryRepository = null;
        public ProductsCategoryController()
        {

            productsCategoryRepository = new ProductsCategoryRepository();
        }

        public IActionResult Index()
        {
            var result = productsCategoryRepository.GetAll();
            return View(result);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(ProductCategory productCategory)
        {
            try
            {
                /*         if (ModelState.IsValid)
                         {*/
                productsCategoryRepository.Insert(productCategory);
                SetAlert("Insert Data is success!", "success");
                return Json(new { success = true });
                /*}*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = false });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductCategory productCategory = productsCategoryRepository.GetById(id);
            var data = new
            {
                Id = productCategory.Id,
                Name = productCategory.CategoryName
                // Các trường khác
            };

            return new JsonResult(new { success = true, data = data });
        }

        [HttpPost]
        public JsonResult Edit(ProductCategory productCategory)
        {
            try
            {
                /*  if (ModelState.IsValid)
                  {*/
                productsCategoryRepository.Update(productCategory);
                SetAlert("Update Data is success!", "success");
                /*}*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(ProductCategory productCategory)
        {
            try
            {
                productsCategoryRepository.Delete(productCategory);
                SetAlert("Delete Data is success!", "success");

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }
    }
}
