using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;
using 期末專題_旅遊網;

namespace 期末專案0924.Controllers
{
    public class HotelInformationController : Controller
    {
        // GET: HotelInformation
        public ActionResult List()
        {
            IEnumerable<tHotelInfomation> hotelInfomations = null;

            int identity = 0;
            if (Session["identity"] != null)
                identity = (int)Session["identity"];
            int firmSN = 0;
            if (Session["sn"] != null)
                firmSN = (int)Session["sn"];

            if (identity == 0)
                return RedirectToAction("Index", "Home");
            else if (identity == 1)
                return RedirectToAction("Index", "Home");
            else if (identity == 2)
            {
                hotelInfomations = from p in (new dbtravelwebEntities()).tHotelInfomation
                                   where p.cFirmSN== firmSN
                                   select p;
            }                
            else
            {
                string keyword = Request.Form["txtKeyword"];
                if (string.IsNullOrEmpty(keyword))
                {
                    hotelInfomations = from p in (new dbtravelwebEntities()).tHotelInfomation
                                       select p;
                }
                else
                {
                    hotelInfomations = from p in (new dbtravelwebEntities()).tHotelInfomation
                                       where p.cFirmTaxID.ToString().Contains(keyword) ||
                                       p.cHotelName.Contains(keyword) ||
                                       p.cHotelNameEN.Contains(keyword) ||
                                       p.cHotelCity.Contains(keyword) ||
                                       p.cHotelAdress.Contains(keyword) ||
                                       p.cHotelPhone.Contains(keyword) ||
                                       p.cHotelType.Contains(keyword)
                                       select p;
                }
            }
            List<CHotelInformationViewModel> models = new List<CHotelInformationViewModel>();
            foreach (tHotelInfomation t in hotelInfomations)
                models.Add(new CHotelInformationViewModel() { hotelInfomation = t });
            return View(models);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbtravelwebEntities db = new dbtravelwebEntities();
                tHotelInfomation prod = db.tHotelInfomation.FirstOrDefault(p => p.cHotelSN == id);
                if (prod != null)
                {
                    db.tHotelInfomation.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Create(int? id)
        {
            Session["FirmSN"] = id;
            //讓View-DeadlineMonths變成下拉式選單
            List<SelectListItem> hoteltypes = new List<SelectListItem>();
            SelectListItem hoteltype = new SelectListItem { Text = "請選擇旅館類型", Value = "請選擇旅館類型" };
            hoteltypes.Add(hoteltype);
            SelectListItem Homestay = new SelectListItem { Text = "民宿", Value = "民宿" };
            hoteltypes.Add(Homestay);
            SelectListItem Hotel = new SelectListItem { Text = "飯店", Value = "飯店" };
            hoteltypes.Add(Hotel);
            //畫面顯示的字串
            //hoteltypes.Where(q => q.Value == "請選擇旅館類型").First().Selected = true;
            ViewBag.HotelType = hoteltypes;
            return View();
        }
        [HttpPost]
        public ActionResult Create(tHotelInfomation p)
        {
            p.cFirmSN = (int)Session["FirmSN"];
            dbtravelwebEntities db = new dbtravelwebEntities();
            db.tHotelInfomation.Add(p);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            tHotelInfomation prod = (new dbtravelwebEntities()).tHotelInfomation.FirstOrDefault(p => p.cHotelSN == id);
            if (prod == null)
                return RedirectToAction("List");
            CHotelInformationViewModel models = new CHotelInformationViewModel() { hotelInfomation = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult Edit(tHotelInfomation input)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tHotelInfomation prod = db.tHotelInfomation.FirstOrDefault(p => p.cHotelSN == input.cHotelSN);
            if (prod != null)
            {
                prod.cFirmTaxID = input.cFirmTaxID;
                prod.cHotelName = input.cHotelName;
                prod.cHotelNameEN = input.cHotelNameEN;
                prod.cHotelCity = input.cHotelCity;
                prod.cHotelAdress = input.cHotelAdress;
                prod.cHotelCreationDate = input.cHotelCreationDate;
                prod.cHotelPhone = input.cHotelPhone;
                prod.cHotelType = input.cHotelType;
                prod.cHotelBarrierfree = input.cHotelBarrierfree;
                db.SaveChanges();
            }
            
            return RedirectToAction("List");
        }
    }
}