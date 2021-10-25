using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class HotelInfomationController : Controller
    {
        // GET: HotelInfomation
        public ActionResult List()
        {
            IEnumerable<tHotelInfomation> HotelInfomations = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                HotelInfomations = from p in (new dbTravelWebEntities()).tHotelInfomation
                                  select p;
            }
            else
            {
                HotelInfomations = from p in (new dbTravelWebEntities()).tHotelInfomation
                                  where p.cHotelName.Contains(keyword) ||
                                  p.cHotelNameEN.Contains(keyword) ||
                                  p.cHotelCity.Contains(keyword) ||
                                  p.cHotelAdress.Contains(keyword) ||
                                  p.cHotelPhone.Contains(keyword) ||
                                  p.cHotelType.Contains(keyword)
                                   select p;
            }
            List<HotelInformationViewModel> models = new List<HotelInformationViewModel>();
            foreach (tHotelInfomation t in HotelInfomations)
               models.Add(new HotelInformationViewModel() { hotelInfomation = t });
            return View(models);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] //處理 Client 的 Post 請求
        public ActionResult Create(tHotelInfomation p)
        {
            dbTravelWebEntities db = new dbTravelWebEntities();
            db.tHotelInfomation.Add(p);
            db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbTravelWebEntities db = new dbTravelWebEntities();
                tHotelInfomation Infomation = db.tHotelInfomation.FirstOrDefault(p => p.cHotelSN == id);
                if (Infomation != null)
                {
                    db.tHotelInfomation.Remove(Infomation);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            tHotelInfomation Infomation = (new dbTravelWebEntities()).tHotelInfomation.FirstOrDefault(p => p.cHotelSN == id);
            if (Infomation == null)
                return RedirectToAction("List");
            return View(Infomation);

        }

        [HttpPost]
        public ActionResult Edit(tHotelInfomation input)
        {
            dbTravelWebEntities db = new dbTravelWebEntities();
            tHotelInfomation Infomation = db.tHotelInfomation.FirstOrDefault(p => p.cHotelSN == input.cHotelSN);
            if (Infomation != null)
            {
                Infomation.cFirmTaxID = input.cFirmTaxID;
                Infomation.cHotelName = input.cHotelName;
                Infomation.cHotelNameEN = input.cHotelNameEN;
                Infomation.cHotelCity = input.cHotelCity;
                Infomation.cHotelAdress = input.cHotelAdress;
                Infomation.cHotelCreationDate = input.cHotelCreationDate;
                Infomation.cHotelPhone = input.cHotelPhone;
                Infomation.cHotelType = input.cHotelType;
                Infomation.cHotelBarrierfree = input.cHotelBarrierfree;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

    }
}