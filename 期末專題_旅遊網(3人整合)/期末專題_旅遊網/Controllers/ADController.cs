using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專題_旅遊網.ViewModels;
using 期末專題_旅遊網.ViewModels.Models;

namespace 期末專題_旅遊網.Controllers
{
    public class ADController : Controller
    {
        // GET: AD
        public ActionResult ADList()
        {
            IQueryable<tAdvertising> q;
            switch (Session["identity"])
            {
                case 2:
                    q = new tADFactory().QueryBySNAll((int)Session["sn"]);
                    return View(tableToViewModel(q));
                case 3:
                    if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                        q = new tADFactory().QueryAll();
                    else
                        q = new tADFactory().QueryByKeyword(Request.Form["txtKeyword"]);
                    return View(tableToViewModel(q));
                default:
                    return RedirectToAction("Index", "Home");
            }            
        }

        public ActionResult ADShow()
        {
            string selectDate = Request.Form["selectDate"];
            if (selectDate == null)
                selectDate = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.Date = selectDate;      

            tADFactory factory = new tADFactory();
            ViewBag.adCount = factory.AdCount(selectDate);
            if (factory.AdCount(selectDate) == 0)
                ViewBag.adCount = 1;
            ViewBag.adName = factory.AdName(selectDate);
            ViewBag.adURL = factory.AdURL(selectDate);

            return View();
        }

        public ActionResult ADUpload(int? hotelSN)
        {        
            switch (Session["identity"])
            {
                case 2:
                    ViewBag.FirmSN = (int)Session["sn"];
                    Session["hotelSN"] = hotelSN;
                    break;
                case 3:
                    ViewBag.FirmSN = 001;
                    break;
                default:
                    return RedirectToAction("Index","Home");
            }

            string inputString = new tADFactory().GetFullDateStr();
            ViewBag.inputStr = inputString;
            return View();
        }
        [HttpPost]
        public ActionResult ADUpload(HttpPostedFileBase image, CADViewModel cADViewModel)
        {
            int hotelSN = (int)Session["hotelSN"];
            if(cADViewModel.cADURL==null)
                cADViewModel.cADURL = $"/Home/SelectRoom?cHotelSN={hotelSN}";
            tADFactory factory = new tADFactory();
            factory.Create(image, cADViewModel);
            return RedirectToAction("ADList");
        }
        public ActionResult ADEdit(int? sn)
        {
            if (sn == null)
            {
                return RedirectToAction("ADShow");
            }
            ViewBag.ADFileName = new tADFactory().QueryBySN((int)sn).cADFileName;

            return View(tableToViewModel(new tADFactory().QueryBySN((int)sn)));
        }
        [HttpPost]
        public ActionResult ADEdit(CADViewModel cADViewModel)
        {
            new tADFactory().Update(cADViewModel);
            return RedirectToAction("ADList");
        }
        public ActionResult ADChangeStatus(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ADShow");
            }
            new tADFactory().ChangeStatus((int)id);

            return RedirectToAction("ADList");
        }

        public ActionResult ADDelete(int? id)
        {
            if (id != null)
            {
                new tADFactory().Delete((int)id);
            }

            return RedirectToAction("ADList");
        }

        //Table轉ViewModel
        List<CADViewModel> tableToViewModel(IQueryable<tAdvertising> tad)
        {
            List<CADViewModel> models = new List<CADViewModel>();
            foreach (tAdvertising ad in tad)
                models.Add(new CADViewModel() { advertising = ad });
            return models;
        }
        CADViewModel tableToViewModel(tAdvertising tad)
        {
            CADViewModel models = new CADViewModel();
            models.advertising = tad;
            return models;
        }
    }
}