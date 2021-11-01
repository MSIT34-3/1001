using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 期末專題_旅遊網;

namespace 期末專案0924.ViewModels
{
    public class CUserOrderViewModel
    {
        public tUserOrder userOrder { get; set; }
        public CUserOrderViewModel() { this.userOrder = new tUserOrder(); }
        [DisplayName("旅客訂單流水號")]
        public int cOrderSN
        {
            get { return this.userOrder.cOrderSN; }
            set { this.userOrder.cOrderSN = value; }
        }
        [DisplayName("旅客訂單編號")]
        public int cOrderID
        {
            get { return this.userOrder.cOrderID; }
            set { this.userOrder.cOrderID = value; }
        }

        [Required(ErrorMessage = "旅客編號不可空白")]
        [DisplayName("旅客編號")]
        public int cGuestSN
        {
            get { return this.userOrder.cGuestSN; }
            set { this.userOrder.cGuestSN = value; }
        }
        [DisplayName("訂購日期")]
        public Nullable<System.DateTime> cOrderDate
        {
            get { return this.userOrder.cOrderDate; }
            set { this.userOrder.cOrderDate = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "入住日期時間不可空白")]
        [DisplayName("入住日期時間")]
        public Nullable<System.DateTime> cCheckInDate
        {
            get { return this.userOrder.cCheckInDate; }
            set { this.userOrder.cCheckInDate = value; }
        }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "退房日期時間不可空白")]
        [DisplayName("退房日期時間")]
        public Nullable<System.DateTime> cCheckOutDate
        {
            get { return this.userOrder.cCheckOutDate; }
            set { this.userOrder.cCheckOutDate = value; }
        }
        [DisplayName("入住天數")]
        public Nullable<int> cStayDays
        {
            get { return this.userOrder.cStayDays; }
            set { this.userOrder.cStayDays = value; }
        }
        [DisplayName("訂單狀態")]
        public string cOrderStatus
        {
            get { return this.userOrder.cOrderStatus; }
            set { this.userOrder.cOrderStatus = value; }
        }

        [DisplayName("員工編號")]
        public Nullable<int> cStaffProfileSN
        {
            get { return this.userOrder.cStaffProfileSN; }
            set { this.userOrder.cStaffProfileSN = value; }
        }

        [DisplayName("飯店房型編號")]
        public int cHotelRoomTypeSN
        {
            get { return this.userOrder.cHotelRoomTypeSN; }
            set { this.userOrder.cHotelRoomTypeSN = value; }
        }
        [StringLength(100, MinimumLength = 0, ErrorMessage = "{0}至少要{2}個字，不超過{1}個字")]
        [DisplayName("訂單備註(ex:預計入住時間、退房時間、抽不抽菸等...)")]
        public string cOrderNotes
        {
            get { return this.userOrder.cOrderNotes; }
            set { this.userOrder.cOrderNotes = value; }
        }

        [DisplayName("訂單總金額")]
        public int cOrderPrice
        {
            get { return this.userOrder.cOrderPrice; }
            set { this.userOrder.cOrderPrice = value; }
        }
    }
}