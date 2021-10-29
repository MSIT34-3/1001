using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;
using 期末專案0924.ViewModels.Models;

namespace 期末專案0924.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm
        public ActionResult FirmList()
        {
            IQueryable<tFirmAccountInfomation> q;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                q = new tFirmAccountInfoFactory().QueryAll();
            else
                q = new tFirmAccountInfoFactory().QueryByKeyword(Request.Form["txtKeyword"]);
            return View(tableToViewModel(q));            
        }
        public ActionResult FirmCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FirmCreate(CFirmAccountInfoViewModel cFirmAccountInfo)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            factory.Create(cFirmAccountInfo);

            return RedirectToAction("FirmList");
        }

        public ActionResult FirmEdit(int cFirmSN)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            tFirmAccountInfomation firm = factory.QueryBySN(cFirmSN);

            return View(tableToViewModel(firm));
        }
        [HttpPost]
        public ActionResult FirmEdit(CFirmAccountInfoViewModel cFirmAccountInfo)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            factory.Update(cFirmAccountInfo);

            return RedirectToAction("FirmList");
        }
        public ActionResult ChangePWD(int cFirmSN)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            tFirmAccountInfomation firm = factory.QueryBySN(cFirmSN);

            return View(tableToViewModel(firm));
        }
        [HttpPost]
        public ActionResult ChangePWD(CFirmAccountInfoViewModel cFirmAccountInfo)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            factory.ChangePWD(cFirmAccountInfo);

            return RedirectToAction("FirmList");
        }
        public ActionResult FirmDelete(int firmSN)
        {
            tFirmAccountInfoFactory factory = new tFirmAccountInfoFactory();
            factory.Delete(firmSN);

            return RedirectToAction("FirmList");
        }


        List<CFirmAccountInfoViewModel> tableToViewModel(IQueryable<tFirmAccountInfomation> tFirmAccountInfo)
        {
            List<CFirmAccountInfoViewModel> models = new List<CFirmAccountInfoViewModel>();
            foreach (tFirmAccountInfomation info in tFirmAccountInfo)
                models.Add(new CFirmAccountInfoViewModel() { firmAccountInfomation = info });
            return models;
        }
        CFirmAccountInfoViewModel tableToViewModel(tFirmAccountInfomation tFirmAccountInfo)
        {
            CFirmAccountInfoViewModel models = new CFirmAccountInfoViewModel();
            models.firmAccountInfomation = tFirmAccountInfo;
            return models;
        }
    }
}