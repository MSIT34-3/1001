using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class GuestPaymentInformationController : Controller
    {
        public ActionResult List()
        {
            IEnumerable<tGuestPaymentInfomation> guestPaymentInfomations = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                guestPaymentInfomations = from p in (new dbtravelwebEntities()).tGuestPaymentInfomation
                                          select p;
            }
            else
            {
                guestPaymentInfomations = from p in (new dbtravelwebEntities()).tGuestPaymentInfomation
                                          where p.cOrderID.ToString().Contains(keyword)
                                            select p;
            }
            List<CGuestPaymentInformationViewModel> models = new List<CGuestPaymentInformationViewModel>();
            foreach (tGuestPaymentInfomation t in guestPaymentInfomations)
                models.Add(new CGuestPaymentInformationViewModel() { guestPaymentInfomation = t });
            return View(models);
        }
        // GET: GuestPaymentInformation
        public ActionResult Create()
        {
            //讓View變成下拉式選單
            List<SelectListItem> DeadlineMonths = new List<SelectListItem>();
            SelectListItem HeadMonth = new SelectListItem { Text = "請選擇月份", Value = "請選擇月份" };
            DeadlineMonths.Add(HeadMonth);
            for (var i = 1;i<13;i++)
            {
                SelectListItem DeadlineMonth = new SelectListItem { Text = $"{i}月", Value = i.ToString() };
                DeadlineMonths.Add(DeadlineMonth);
            }
            DeadlineMonths.Where(q => q.Value == "請選擇月份").First().Selected = true;
            ViewBag.Month = DeadlineMonths;

            List<SelectListItem> DeadlineYears = new List<SelectListItem>();
            SelectListItem HeadYear = new SelectListItem { Text = "請選擇年份", Value = "請選擇年份" };
            DeadlineYears.Add(HeadYear);
            for (var i = 2021; i < 2036; i++)
            {
                SelectListItem DeadlineYear = new SelectListItem { Text = $"{i}", Value = i.ToString() };
                DeadlineYears.Add(DeadlineYear);
            }
            DeadlineYears.Where(p => p.Value == "請選擇年份").First().Selected = true;
            ViewBag.Year = DeadlineYears;
            return View();
        }
        [HttpPost]
        public ActionResult Create(tGuestPaymentInfomation p)
        {
            Session["tGuestPaymentInfomation"] = p;
            //dbtravelwebEntities db = new dbtravelwebEntities();
            //db.tGuestPaymentInfomation.Add(p);
            //db.SaveChanges();
            
            return RedirectToAction("CheckOrder", new { id = p.cOrderID });
        }

        public ActionResult CheckOrder(int? id)
        {
            
            tUserOrder prod = (tUserOrder)Session["Data"];
            tGuestPaymentInfomation pay = (tGuestPaymentInfomation)Session["tGuestPaymentInfomation"];

            //tGuestPaymentInfomation pay = (new dbtravelwebEntities()).tGuestPaymentInfomation.FirstOrDefault(q => q.cOrderID == id);
            CheckOrderViewModel models = new CheckOrderViewModel() { userOrder = prod , guestPaymentInfomation = pay };
            return View(models);
        }
        [HttpPost]
        public ActionResult CheckOrder(tGuestPaymentInfomation q)
        {
            if (this.ModelState.IsValid == true)
            {
                tUserOrder p = (tUserOrder)Session["Data"];
                tGuestPaymentInfomation pay = (tGuestPaymentInfomation)Session["tGuestPaymentInfomation"];
                dbtravelwebEntities db = new dbtravelwebEntities();
                
                db.tGuestPaymentInfomation.Add(pay);
                db.tUserOrder.Add(p);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbtravelwebEntities db = new dbtravelwebEntities();
                tUserOrder prod = db.tUserOrder.FirstOrDefault(p => p.cOrderID == id);
                tGuestPaymentInfomation pay = db.tGuestPaymentInfomation.FirstOrDefault(q => q.cOrderID == id);
                if (prod != null)
                {
                    db.tUserOrder.Remove(prod);
                    db.SaveChanges();
                }
                if (pay != null)
                {
                    db.tGuestPaymentInfomation.Remove(pay);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}