using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels.Models
{
    public class tHotelInfo
    {
        public int cHotelSN { get; set; }
        public int cFirmSN { get; set; }
        public string cFirmTaxID { get; set; }
        public string cHotelName { get; set; }
        public string cHotelNameEN { get; set; }
        public string cHotelCity { get; set; }
        public string cHotelAdress { get; set; }
        public DateTime cHotelCreationDate { get; set; }
        public string cHotelInfoPhotoName { get; set; }
        public string cHotelInfoPhotoFileName { get; set; }
        public string cHotelPhone { get; set; }
        public string cHotelAverageRating { get; set; }
        public string cHotelRatingOfPeople { get; set; }
        public string cHotelType { get; set; }
        public bool cHotelBarrierfree { get; set; }
        public string cHotelVisitors { get; set; }
    }
}