using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
/*        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var user = User as ClaimsPrincipal;
            var userName = user?.FindFirstValue(ClaimTypes.Name);
            if (userName == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
 RouteValueDictionary(new
 {
     controller = "Login",
     action = "Index",
     Areas = "Admin"
 }));
            }
            base.OnActionExecuted(filterContext);
        }*/
        public void SetAlert(string msg, string type)
        {
            TempData["AlertMessage"] = msg;
            if (type == "success")
            {
                TempData["Type"] = "alert-success";
            }
            if (type == "warning")
            {
                TempData["Type"] = "alert-warning";
            }
            if (type == "error")
            {
                TempData["Type"] = "alert-danger";
            }
        }
    }
}
