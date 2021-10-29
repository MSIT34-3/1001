using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class CheckOrderViewModel
    {
        public tUserOrder userOrder { get; set; }
        public tGuestPaymentInfomation guestPaymentInfomation { get; set; }
        public CheckOrderViewModel() { this.userOrder = new tUserOrder(); this.guestPaymentInfomation = new tGuestPaymentInfomation(); }
       
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

        [DisplayName("訂單價格")]
        public int cOrderPrice
        {
            get { return this.userOrder.cOrderPrice; }
            set { this.userOrder.cOrderPrice = value; }
        }
        [DisplayName("旅客付款資訊編號")]
        public int cGuestPaymentInfoSN
        {
            get { return this.guestPaymentInfomation.cGuestPaymentInfoSN; }
            set { this.guestPaymentInfomation.cGuestPaymentInfoSN = value; }
        }
        
        [Required(ErrorMessage = "信用卡類型不可空白")]
        [DisplayName("信用卡類型")]
        public string cCreditCardType
        {
            get { return this.guestPaymentInfomation.cCreditCardType; }
            set { this.guestPaymentInfomation.cCreditCardType = value; }
        }
        [Required(ErrorMessage = "持卡人姓名不可空白")]
        [DisplayName("持卡人姓名")]
        public string cGuestCreditCardName
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardName; }
            set { this.guestPaymentInfomation.cGuestCreditCardName = value; }
        }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "持卡人生日不可空白")]
        [DisplayName("持卡人生日")]
        public Nullable<System.DateTime> cGuestCreditCardBirth
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardBirth; }
            set { this.guestPaymentInfomation.cGuestCreditCardBirth = value; }
        }
        [Required(ErrorMessage = "身分證字號不可空白")]
        [DisplayName("身分證字號")]
        public string cGuestCreditCardNameID
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardNameID; }
            set { this.guestPaymentInfomation.cGuestCreditCardNameID = value; }
        }
        [Required(ErrorMessage = "信用卡卡號不可空白")]
        [DisplayName("信用卡卡號")]
        public string cGuestCreditCardNumber
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardNumber; }
            set { this.guestPaymentInfomation.cGuestCreditCardNumber = value; }
        }
        [Required(ErrorMessage = "有效期限(月)不可空白")]
        [DisplayName("有效期限(月)")]
        public Nullable<int> cGuestCreditCardDeadlineMonth
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardDeadlineMonth; }
            set { this.guestPaymentInfomation.cGuestCreditCardDeadlineMonth = value; }
        }
        [Required(ErrorMessage = "有效期限(年)不可空白")]
        [DisplayName("有效期限(年)")]
        public Nullable<int> cGuestCreditCardDeadlineYear
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardDeadlineYear; }
            set { this.guestPaymentInfomation.cGuestCreditCardDeadlineYear = value; }
        }
        [Required(ErrorMessage = "安全碼不可空白")]
        [DisplayName("安全碼")]
        public Nullable<int> cGuestCreditCardSecurityCode
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardSecurityCode; }
            set { this.guestPaymentInfomation.cGuestCreditCardSecurityCode = value; }
        }
    }
}