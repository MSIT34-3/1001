using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 期末專題_旅遊網;

namespace 期末專案0924.ViewModels
{
    public class CHotelRoomTypeViewModel
    {
        public tHotelRoomType hotelRoomTypes { get; set; }
        public CHotelRoomTypeViewModel() { this.hotelRoomTypes = new tHotelRoomType(); }
        
        [DisplayName("飯店房型編號")]
        public int cHotelRoomTypeSN
        {
            get { return this.hotelRoomTypes.cHotelRoomTypeSN; }
            set { this.hotelRoomTypes.cHotelRoomTypeSN = value; }
        }
        [Required(ErrorMessage = "廠商編號不可空白")]
        [DisplayName("廠商編號編號")]
        public Nullable<int> cFirmSN
        {
            get { return this.hotelRoomTypes.cFirmSN; }
            set { this.hotelRoomTypes.cFirmSN = value; }
        }
        [DisplayName("飯店編號")]
        public int cHotelSN
        {
            get { return this.hotelRoomTypes.cHotelSN; }
            set { this.hotelRoomTypes.cHotelSN = value; }
        }
        [Required(ErrorMessage = "飯店房型名稱不可空白")]
        [DisplayName("飯店房型名稱")]
        public string cHotelRoomTypeName
        {
            get { return this.hotelRoomTypes.cHotelRoomTypeName; }
            set { this.hotelRoomTypes.cHotelRoomTypeName = value; }
        }
        
        [Required(ErrorMessage = "房間總數目不可空白")]
        [DisplayName("房間總數目")]
        public int cHotelRoomCount
        {
            get { return this.hotelRoomTypes.cHotelRoomCount; }
            set { this.hotelRoomTypes.cHotelRoomCount = value; }
        }
        [Required(ErrorMessage = "可容量最大總人數不可空白")]
        [DisplayName("可容量最大總人數")]
        public int cHotelRoomContain
        {
            get { return this.hotelRoomTypes.cHotelRoomContain; }
            set { this.hotelRoomTypes.cHotelRoomContain = value; }
        }
       
        [Required(ErrorMessage = "可容量成人人數不可空白")]
        [DisplayName("可容量成人人數")]
        public int cHotelRoomContainAldults
        {
            get { return this.hotelRoomTypes.cHotelRoomContainAldults; }
            set { this.hotelRoomTypes.cHotelRoomContainAldults = value; }
        }
       
        [Required(ErrorMessage = "可容量孩童人數不可空白")]
        [DisplayName("可容量孩童人數")]
        public int cHotelRoomContainChiidren
        {
            get { return this.hotelRoomTypes.cHotelRoomContainChiidren; }
            set { this.hotelRoomTypes.cHotelRoomContainChiidren = value; }
        }
        
        [Required(ErrorMessage = "飯店房型價格不可空白")]
        [DisplayName("飯店房型價格")]
        public int cHotelRoomTypePriceOfWeekdays
        {
            get { return this.hotelRoomTypes.cHotelRoomTypePriceOfWeekdays; }
            set { this.hotelRoomTypes.cHotelRoomTypePriceOfWeekdays = value; }
        }
        [Required(ErrorMessage = "飯店房型價格(假日)不可空白")]
        [DisplayName("飯店房型價格(假日)")]
        public int cHotelRoomTypePriceOfHoliday
        {
            get { return this.hotelRoomTypes.cHotelRoomTypePriceOfHoliday; }
            set { this.hotelRoomTypes.cHotelRoomTypePriceOfHoliday = value; }
        }
        [Required(ErrorMessage = "飯店房型價格(節慶)不可空白")]
        [DisplayName("飯店房型價格(節慶)")]
        public int cHotelRoomTypePriceOfFestival
        {
            get { return this.hotelRoomTypes.cHotelRoomTypePriceOfFestival; }
            set { this.hotelRoomTypes.cHotelRoomTypePriceOfFestival = value; }
        }
    }
}