using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.Models
{
    public class cUserOrder
    {
        public int cOrderSN { get; set; }
        public int cOrderID { get; set; }
        public int cGuestSN { get; set; }
        public DateTime cOrderDate { get; set; }
        public DateTime cCheckInDate { get; set; }
        public DateTime cCheckOutDate { get; set; }
        public string cOrderStatus { get; set; }
        public int? cStaffProfileSN { get; set; }
        public int cHotelRoomTypeSN { get; set; }
        public string cOrderNotes { get; set; }
        public decimal cOrderPrice { get; set; }


    }
}