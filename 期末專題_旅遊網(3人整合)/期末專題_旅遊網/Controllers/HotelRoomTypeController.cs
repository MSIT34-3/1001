using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.ViewModels;
using 期末專題_旅遊網;

namespace 期末專案0924.Controllers
{
    public class HotelRoomTypeController : Controller
    {
        // GET: HotelRoomType
        public ActionResult List(int? id ,int? FirmSN)
        {
            
            IEnumerable<tHotelRoomType> hotelRoomTypes = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                hotelRoomTypes = from p in (new dbtravelwebEntities()).tHotelRoomType
                                 where p.cHotelSN == id
                                   select p;
            }
            else
            {
                hotelRoomTypes = from p in (new dbtravelwebEntities()).tHotelRoomType
                                 where p.cHotelSN == id && 
                                 p.cHotelRoomTypeName.ToString().Contains(keyword)
                                  select p;
            }
            List<CHotelRoomTypeViewModel> models = new List<CHotelRoomTypeViewModel>();
            
            foreach (tHotelRoomType t in hotelRoomTypes)
                models.Add(new CHotelRoomTypeViewModel() { hotelRoomTypes = t });
            //如果沒資料直接跳Create 有資料的話跳List
            if (models.Count == 0)
            {
                return RedirectToAction("Create", new { id , FirmSN });
            }
            else
            {
                return View(models);
            }
            
        }
        public ActionResult Delete(int? id)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tHotelRoomType prod = db.tHotelRoomType.FirstOrDefault(p => p.cHotelRoomTypeSN == id);
            if (prod != null)
            {
                db.tHotelRoomType.Remove(prod);
                db.SaveChanges();
            }
            //如果刪除房型管理資料後 List為0 會跳回飯店管理
            tHotelRoomType RoomZero = db.tHotelRoomType.FirstOrDefault(p => p.cHotelSN == prod.cHotelSN);
            if (RoomZero == null)
            {
                return RedirectToAction("List", "HotelInformation", new { id = prod.cHotelSN });
            }
            return RedirectToAction("List",new { id = prod.cHotelSN });
        }
        public ActionResult Create(int? id ,int? FirmSN)
        {
            //tHotelRoomType pay = (new dbtravelwebEntities()).tHotelRoomType.FirstOrDefault(q => q.cHotelSN == id);
            Session["tHotelRoomTypeHotelSN"] = id;
            Session["tHotelRoomTypeFirmSN"] = FirmSN;
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase image, tHotelRoomType p)
        {
            string savePath = "E:/資策會/003專題/GitHub/Travel/期末專題_旅遊網(3人整合)/期末專題_旅遊網/img/HotelImage/RoomImage/";
            //string savePath = "D:/期末專案/GitHub/1001/期末專題_旅遊網(3人整合)/期末專題_旅遊網/img/HotelImage/RoomImage/";
            string HotelFileName = DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.Millisecond + "-" + image.FileName;
            image.SaveAs(savePath + HotelFileName);

            p.cHotelRoomTypePhoto = HotelFileName;

            p.cHotelSN = (int)Session["tHotelRoomTypeHotelSN"];
            p.cFirmSN = (int)Session["tHotelRoomTypeFirmSN"];
            dbtravelwebEntities db = new dbtravelwebEntities();
            db.tHotelRoomType.Add(p);
            db.SaveChanges();
            
            return RedirectToAction("List",new { id = p.cHotelSN });
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
                //prod.cHotelSN = (int)Session["tHotelRoomType"];
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
            return RedirectToAction("List", new { id = prod.cHotelSN });
        }
    }
}