using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924;
using 期末專案0924.Models;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class ADController : Controller
    {
        // GET: AD        
        public ActionResult ADList()
        {
            IQueryable<tAdvertising> q;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                q = new tADFactory().QueryAll();
            else
                q = new tADFactory().QueryByKeyword(Request.Form["txtKeyword"]);
            return View(tableToViewModel(q));
        }

        public ActionResult ADShow()
        {
            tADFactory factory = new tADFactory();
            ViewBag.adCount = factory.AdCount();
            if (factory.AdCount() == 0)
                ViewBag.adCount = 1;
            ViewBag.adName = factory.AdName();
            ViewBag.adURL = factory.AdURL();

            return View();
        }

        public ActionResult ADUpload()
        {
            string inputString = new tADFactory().GetFullDateStr();
            ViewBag.inputStr = inputString;
            return View();
        }
        [HttpPost]
        public ActionResult ADUpload(HttpPostedFileBase image, tAD tad)
        {
            tADFactory factory = new tADFactory();
            factory.Create(image, tad);

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