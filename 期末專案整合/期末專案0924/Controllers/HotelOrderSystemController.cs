using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.Model;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class HotelOrderSystemController : Controller
    {
        // GET: HotelOrderSystem
        public ActionResult List(int? id, int? HotelId)
        {
            //如果沒資料直接跳Create 有資料的話跳List
            IEnumerable<tHotelOrderSystem> hotelOrderSystems = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                hotelOrderSystems = from p in (new dbtravelwebEntities()).tHotelOrderSystem
                                    where p.cHotelRoomTypeSN == id
                                    select p;
            }
            else
            {
                hotelOrderSystems = from p in (new dbtravelwebEntities()).tHotelOrderSystem
                                    where p.cHotelRoomTypeSN == id &&
                                    p.OrderDate.ToString().Contains(keyword)
                                    select p;
            }
            List<CHotelOrderSystemViewModel> models = new List<CHotelOrderSystemViewModel>();
            foreach (tHotelOrderSystem t in hotelOrderSystems)
                models.Add(new CHotelOrderSystemViewModel() { hotelOrderSystem = t });
            if (models.Count == 0)
            {
                return RedirectToAction("Create", new { id, HotelId });
            }
            return View(models);
        }
        public ActionResult Delete(int? id)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tHotelOrderSystem prod = db.tHotelOrderSystem.FirstOrDefault(p => p.OrderSystemSN == id);

            if (prod != null)
            {
                db.tHotelOrderSystem.Remove(prod);
                db.SaveChanges();
            }
            //如果刪除訂單系統資料後 List為0 會跳回房型管理
            tHotelOrderSystem OrderZero = db.tHotelOrderSystem.FirstOrDefault(p => p.cHotelRoomTypeSN == prod.cHotelRoomTypeSN);
            if (OrderZero == null)
            {
                return RedirectToAction("List", "HotelRoomType", new { id = prod.cHotelSN });
            }
            return RedirectToAction("List", new { id = prod.cHotelRoomTypeSN });
        }
        public ActionResult Create(int? id, int? HotelId)
        {
            Session["tHotelOrderSystemRoomSN"] = id;
            Session["tHotelOrderSystemHotelSN"] = HotelId;
            return View();
        }
        [HttpPost]
        public ActionResult Create(tHotelOrderSystem p)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            p.cHotelRoomTypeSN = (int)Session["tHotelOrderSystemRoomSN"];
            p.cHotelSN = (int)Session["tHotelOrderSystemHotelSN"];
            db.tHotelOrderSystem.Add(p);
            db.SaveChanges();

            return RedirectToAction("List", new { id = p.cHotelRoomTypeSN, HotelId = p.cHotelSN });
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
                return RedirectToAction("List");

            tHotelOrderSystem prod = (new dbtravelwebEntities()).tHotelOrderSystem.FirstOrDefault(p => p.OrderSystemSN == id);
            Session["OrderSystemEditHotelSN"] = prod.cHotelSN;
            if (prod == null)
                return RedirectToAction("List");
            CHotelOrderSystemViewModel models = new CHotelOrderSystemViewModel() { hotelOrderSystem = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult Edit(tHotelOrderSystem input)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tHotelOrderSystem prod = db.tHotelOrderSystem.FirstOrDefault(p => p.OrderSystemSN == input.OrderSystemSN);
            if (prod != null)
            {
                prod.cHotelRoomTypeSN = input.cHotelRoomTypeSN;
                prod.cHotelSN = (int)Session["OrderSystemEditHotelSN"];
                prod.OrderDate = input.OrderDate;
                prod.CanBookNumber = input.CanBookNumber;
                prod.BookedNumber = input.BookedNumber;
                db.SaveChanges();
            }

            return RedirectToAction("List", new { id = prod.cHotelRoomTypeSN , HotelId  = prod.cHotelSN});
        }
    }
}