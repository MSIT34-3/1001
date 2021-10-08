using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專案0924.Models;

namespace 期末專案0924.Controllers
{
    public class UserOrderController : Controller
    {
        
        public ActionResult List()
        {
            List<cUserOrder> UserOrders = null;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
            {
                UserOrders = (new UserOrderFactory()).queryAll();
            }
            else
            {
                UserOrders = (new UserOrderFactory()).queryByKetword(Request.Form["txtKeyword"]);
            }
            return View(UserOrders);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]//避免出現模玲兩可
        public ActionResult Create(cUserOrder x)
        {
            //cUserOrder x = new cUserOrder();放入參數即可省略這行
            x.cOrderID = Convert.ToInt32(Request.Form["txtOrderID"]);
            x.cGuestSN = Convert.ToInt32(Request.Form["txtGuestSN"]);
            x.cOrderDate = Convert.ToDateTime(Request.Form["txtOrderDate"]);
            x.cCheckInDate = Convert.ToDateTime(Request.Form["txtCheckInDate"]);
            x.cCheckOutDate = Convert.ToDateTime(Request.Form["txtCheckOutDate"]);
            x.cHotelRoomTypeSN = Convert.ToInt32(Request.Form["txtHotelRoomTypeSN"]);
            x.cOrderNotes = Request.Form["txtOrderNotes"];
            x.cOrderPrice = Convert.ToDecimal(Request.Form["txtOrderPrice"]);
            (new UserOrderFactory()).create(x);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            cUserOrder x = (new UserOrderFactory()).queryById((int)id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Edit(cUserOrder x)
        {
            (new UserOrderFactory()).update(x);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
                (new UserOrderFactory()).delete((int)id);
            return RedirectToAction("List");
        }
    }
}