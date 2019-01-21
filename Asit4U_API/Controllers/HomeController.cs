using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asit4U_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult Test(string user)
        {
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = "hello"
            };

            return result;
        }

        public JsonResult Multiply(int x, int y)
        {
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    left = x,
                    right = y,
                    result = x * y,
                    meta = string.Format("{0} * {1} = {2}", x, y, x * y)
                }
            };
            return result;
        }
    }
}
