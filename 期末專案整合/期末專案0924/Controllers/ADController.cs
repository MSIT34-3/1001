using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST3.Models;

namespace TEST3.Controllers
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
            return View(q);
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
            
            return View(new tADFactory().QueryBySN((int)sn));
        }
        [HttpPost]
        public ActionResult ADEdit(tAdvertising tAdvertising)
        {
            new tADFactory().Update(tAdvertising);
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

        public ActionResult ADDelete(int? sn)
        {
            if(sn!=null)
            {
                new tADFactory().Delete((int)sn);
            }

            return RedirectToAction("ADList");
        }
    }
}