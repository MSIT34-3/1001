using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 期末專題_旅遊網;

namespace 期末專案0924.ViewModels
{
    public class CHotelOrderSystemViewModel
    {
        public tHotelOrderSystem hotelOrderSystem { get; set; }
        public CHotelOrderSystemViewModel() { this.hotelOrderSystem = new tHotelOrderSystem(); }
        [Required(ErrorMessage = "訂單系統編號不可空白")]
        [DisplayName("訂單系統編號")]
        public int OrderSystemSN
        {
            get { return this.hotelOrderSystem.OrderSystemSN; }
            set { this.hotelOrderSystem.OrderSystemSN = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "日期不可空白")]
        [DisplayName("日期")]
        public System.DateTime OrderDate
        {
            get { return this.hotelOrderSystem.OrderDate; }
            set { this.hotelOrderSystem.OrderDate = value; }
        }
        [Required(ErrorMessage = "飯店編號不可空白")]
        [DisplayName("飯店編號")]
        public int cHotelSN
        {
            get { return this.hotelOrderSystem.cHotelSN; }
            set { this.hotelOrderSystem.cHotelSN = value; }
        }
        [Required(ErrorMessage = "飯店房型編號不可空白")]
        [DisplayName("飯店房型編號")]
        public int cHotelRoomTypeSN
        {
            get { return this.hotelOrderSystem.cHotelRoomTypeSN; }
            set { this.hotelOrderSystem.cHotelRoomTypeSN = value; }
        }
        [Required(ErrorMessage = "可用房數不可空白")]
        [DisplayName("可用房數")]
        public int CanBookNumber
        {
            get { return this.hotelOrderSystem.CanBookNumber; }
            set { this.hotelOrderSystem.CanBookNumber = value; }
        }
        [Required(ErrorMessage = "已訂房數不可空白")]
        [DisplayName("已訂房數")]
        public int BookedNumber
        {
            get { return this.hotelOrderSystem.BookedNumber; }
            set { this.hotelOrderSystem.BookedNumber = value; }
        }
    }
}