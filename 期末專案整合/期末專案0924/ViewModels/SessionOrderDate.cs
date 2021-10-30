using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class SessionOrderDate
    {
        public DateTime CheckIndate { get; set; }
        public DateTime CheckOutdate { get; set; }
        public int StayDays { get; set; }
        public int HotelRoomTypeSN { get; set; }
        public int TotalPrice { get; set; }
    }
}