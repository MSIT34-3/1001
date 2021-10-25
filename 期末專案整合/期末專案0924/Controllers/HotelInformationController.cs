using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class HotelInformationController : Controller
    {
        // GET: HotelInformation
        public ActionResult List()
        {
            IEnumerable<tHotelInfomation> hotelInfomations = null;
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
                                   p.cHotelType.Contains(keyword) ||
                                   p.cHotelBarrierfree.ToString().Contains(keyword)
                                   select p;
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tHotelInfomation p)
        {
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
            return View(prod);
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