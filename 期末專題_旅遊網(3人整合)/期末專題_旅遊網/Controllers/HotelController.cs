using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專題_旅遊網.ViewModels;
using 期末專題_旅遊網.ViewModels.Models;

namespace 期末專題_旅遊網.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult HotelList()
        {
            int identity = 0;
            if (Session["identity"] != null)
                identity = (int)Session["identity"];
            int firmSN = 0;
            if (Session["sn"] != null)
                firmSN = (int)Session["sn"];

            IQueryable<tHotelInfomation> q;

            if (identity == 0)
                return RedirectToAction("Index","Home");
            else if (identity == 1)
                return RedirectToAction("Index", "Home");
            else if (identity == 2)
                q = new tHotelInfoFactory().QueryByFirmSN(firmSN);
            else
            {
                ViewBag.Search = 1;
                if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                    q = new tHotelInfoFactory().QueryAll();
                else
                    q = new tHotelInfoFactory().QueryByKeyword(Request.Form["txtKeyword"]);
            }

            return View(tableToViewModel(q));
        }
        public ActionResult HotelCreate()
        {
            return View();
        }



        List<CHotelInfoViewModel> tableToViewModel(IQueryable<tHotelInfomation> tHotelInfomation)
        {
            List<CHotelInfoViewModel> models = new List<CHotelInfoViewModel>();
            foreach (tHotelInfomation info in tHotelInfomation)
                models.Add(new CHotelInfoViewModel() { hotelInfomation = info });
            return models;
        }
        CHotelInfoViewModel tableToViewModel(tHotelInfomation tHotelInfomation)
        {
            CHotelInfoViewModel models = new CHotelInfoViewModel();
            models.hotelInfomation = tHotelInfomation;
            return models;
        }
    }
}