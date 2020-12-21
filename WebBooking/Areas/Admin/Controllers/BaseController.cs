using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBooking.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(Session["IDNhanVien"].ToString() == "")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { area = "Admin", Controller = "Manager", Action = "Login" })
                    ); ;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}