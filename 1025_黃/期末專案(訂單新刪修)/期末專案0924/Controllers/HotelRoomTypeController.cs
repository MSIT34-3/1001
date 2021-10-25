using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class HotelRoomTypeController : Controller
    {
        // GET: HotelRoomType
        public ActionResult List()
        {
            IEnumerable<tHotelRoomType> hotelRoomTypes = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                hotelRoomTypes = from p in (new dbtravelwebEntities()).tHotelRoomType
                                   select p;
            }
            else
            {
                hotelRoomTypes = from p in (new dbtravelwebEntities()).tHotelRoomType
                                 where p.cHotelRoomTypeName.ToString().Contains(keyword)
                                   select p;
            }
            List<CHotelRoomTypeViewModel> models = new List<CHotelRoomTypeViewModel>();
            foreach (tHotelRoomType t in hotelRoomTypes)
                models.Add(new CHotelRoomTypeViewModel() { hotelRoomTypes = t });
            return View(models);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbtravelwebEntities db = new dbtravelwebEntities();
                tHotelRoomType prod = db.tHotelRoomType.FirstOrDefault(p => p.cHotelRoomTypeSN == id);
                if (prod != null)
                {
                    db.tHotelRoomType.Remove(prod);
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
        public ActionResult Create(tHotelRoomType p)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            db.tHotelRoomType.Add(p);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            tHotelRoomType prod = (new dbtravelwebEntities()).tHotelRoomType.FirstOrDefault(p => p.cHotelRoomTypeSN == id);
            if (prod == null)
                return RedirectToAction("List");
            CHotelRoomTypeViewModel models = new CHotelRoomTypeViewModel() { hotelRoomTypes = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult Edit(tHotelRoomType input)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tHotelRoomType prod = db.tHotelRoomType.FirstOrDefault(p => p.cHotelRoomTypeSN == input.cHotelRoomTypeSN);
            if (prod != null)
            {
                prod.cHotelRoomTypeName = input.cHotelRoomTypeName;
                prod.cHotelRoomCount = input.cHotelRoomCount;
                prod.cHotelRoomContain = input.cHotelRoomContain;
                prod.cHotelRoomContainAldults = input.cHotelRoomContainAldults;
                prod.cHotelRoomContainChiidren = input.cHotelRoomContainChiidren;
                prod.cHotelRoomTypePriceOfWeekdays = input.cHotelRoomTypePriceOfWeekdays;
                prod.cHotelRoomTypePriceOfHoliday = input.cHotelRoomTypePriceOfHoliday;
                prod.cHotelRoomTypePriceOfFestival = input.cHotelRoomTypePriceOfFestival;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}