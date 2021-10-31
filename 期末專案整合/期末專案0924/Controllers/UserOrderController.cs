using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.Model;
using 期末專案0924.ViewModels;

namespace 期末專案0924.Controllers
{
    public class UserOrderController : Controller
    {
        // GET: UserOrder
        public ActionResult List()
        {
            IEnumerable<tUserOrder> userOrders = null;
            string keyword = Request.Form["txtKeyword"];
            if (string.IsNullOrEmpty(keyword))
            {
                userOrders = from p in (new dbtravelwebEntities()).tUserOrder
                                   select p;
            }
            else
            {
                userOrders = from p in (new dbtravelwebEntities()).tUserOrder
                             where p.cGuestSN.ToString().Contains(keyword) ||
                                   p.cCheckInDate.ToString().Contains(keyword) ||
                                   p.cCheckOutDate.ToString().Contains(keyword) ||
                                   p.cOrderStatus.Contains(keyword) ||
                                   p.cStaffProfileSN.ToString().Contains(keyword) ||
                                   p.cOrderNotes.Contains(keyword) ||
                                   p.cOrderPrice.ToString().Contains(keyword)
                                   select p;
            }
            List<CUserOrderViewModel> models = new List<CUserOrderViewModel>();
            foreach (tUserOrder t in userOrders)
                models.Add(new CUserOrderViewModel() { userOrder = t });
            return View(models);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                dbtravelwebEntities db = new dbtravelwebEntities();
                tUserOrder prod = db.tUserOrder.FirstOrDefault(p => p.cOrderSN == id);
                if (prod != null)
                {
                    db.tUserOrder.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Create(int HotelRoom,int HotelPrice)
        {
            //分別抓首頁搜尋資料及確認的房型
            SessionOrderDate sessionOrderDate = (SessionOrderDate)Session[CDictionary.SK_USER_ORDER];
            tUserOrder prod = (new dbtravelwebEntities()).tUserOrder.Create();
            prod.cCheckInDate = sessionOrderDate.CheckIndate;
            prod.cCheckOutDate = sessionOrderDate.CheckOutdate;
            prod.cStayDays = sessionOrderDate.StayDays;
            prod.cHotelRoomTypeSN = HotelRoom;
            prod.cOrderPrice = HotelPrice * (sessionOrderDate.StayDays);
            CUserOrderViewModel models = new CUserOrderViewModel() { userOrder = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult Create(tUserOrder p)
        {
            
            //dbtravelwebEntities db = new dbtravelwebEntities();
            p.cOrderDate = DateTime.Now;

            //訂單編號=GuestSN+五碼隨機碼
            Random rnd = new Random();
            string randomArry = (rnd.Next(1, 10)).ToString() + (rnd.Next(1, 10)).ToString() +
                (rnd.Next(1, 10)).ToString() + (rnd.Next(1, 10)).ToString() + (rnd.Next(1, 10)).ToString();
            p.cOrderID = Convert.ToInt32((p.cGuestSN).ToString() + randomArry);
            if (p.cOrderStatus == null)
                p.cOrderStatus = "審核中";
            if (p.cStaffProfileSN.ToString() == "")
                p.cStaffProfileSN = -1;
            Session["Data"] = p;
            //db.tUserOrder.Add(p);
            //db.SaveChanges();
            //到時候在上面加價格...要鎖起來
            return RedirectToAction("Create", "GuestPaymentInformation",new { p.cOrderID});
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");

            tUserOrder prod = (new dbtravelwebEntities()).tUserOrder.FirstOrDefault(p => p.cOrderSN == id);
            //Date HotelCreationDate = Date.Parse(prod.cCheckInDate.ToString());
            //prod.cCheckInDate = HotelCreationDate;
            if (prod == null)
                return RedirectToAction("List");
            //為了連ViewModel
            CUserOrderViewModel models = new CUserOrderViewModel() { userOrder = prod };
            return View(models);
        }
        [HttpPost]
        public ActionResult Edit(tUserOrder input)
        {
            dbtravelwebEntities db = new dbtravelwebEntities();
            tUserOrder prod = db.tUserOrder.FirstOrDefault(p => p.cOrderSN == input.cOrderSN);
            if (prod != null)
            {
                prod.cOrderDate = DateTime.Now;
                prod.cCheckInDate = input.cCheckInDate;
                prod.cCheckOutDate = input.cCheckOutDate;
                prod.cOrderNotes = input.cOrderNotes;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}