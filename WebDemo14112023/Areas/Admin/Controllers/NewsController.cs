using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : BaseController
    {
        INewsRepository newsRepository = null;
        public NewsController()
        {
            newsRepository = new NewsRepository();
        }
        public IActionResult Index()
        {
            IEnumerable<NewsCategory> newsCategory = newsRepository.GetAllNewsCategory();
            // Tạo SelectList từ danh sách quyền truy cập
            SelectList selectList = new SelectList(newsCategory, "Id", "CategoryName");

            // Lưu SelectList vào ViewBag để sử dụng trong View
            ViewBag.NewsCategory = selectList;
            var newsList = newsRepository.GetAll();
            return View(newsList);
        }


        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            ViewBag.NewsCategory = new SelectList(newsRepository.GetAllNewsCategory(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public JsonResult Create(News news)
        {
            try
            {
                // Lấy giá trị từ các trường thuộc tính của user trong form
                var model = new News
                {
                    Title = news.Title,
                    Description = news.Description,
                    SubjectContent = news.SubjectContent,
                    CategoryId = news.CategoryId,
                    Avatar = news.Avatar,
                    Status = news.Status
                };
                model.DateUpdate = Common.Common.GetServerDateTime();
                model.UserId = 1;
                newsRepository.Insert(model);
               
                SetAlert("Insert Data is success!", "success");

                /* }*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

    }
}
