using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        {
            ViewBag.ShowA = "A";            
            ViewBag.ShowB = "B";            
            return View();
        }
        [HttpPost]
        public ActionResult Create(tAdvertising tAdvertising)
        {
            ViewBag.Date = tAdvertising.cADActionDate;        
            return View();
        }
    }
}