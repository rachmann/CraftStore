using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CraftStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Decription page.";

            return View();
        }
    
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Services page.";

            return View();
        }
        public ActionResult Details()
        {
            ViewBag.Message = "Details page.";

            return View();
        }
    }
}