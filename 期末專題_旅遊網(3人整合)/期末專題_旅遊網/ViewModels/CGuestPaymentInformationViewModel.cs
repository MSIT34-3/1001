using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 期末專題_旅遊網;

namespace 期末專案0924.ViewModels
{
    public class CGuestPaymentInformationViewModel
    {
        public tGuestPaymentInfomation guestPaymentInfomation { get; set; }
        public CGuestPaymentInformationViewModel() { this.guestPaymentInfomation = new tGuestPaymentInfomation(); }

        
        [DisplayName("旅客付款資訊編號")]
        public int cGuestPaymentInfoSN
        {
            get { return this.guestPaymentInfomation.cGuestPaymentInfoSN; }
            set { this.guestPaymentInfomation.cGuestPaymentInfoSN = value; }
        }
        [Required(ErrorMessage = "旅客訂單編號不可空白")]
        [DisplayName("旅客訂單編號")]
        public Nullable<int> cOrderID
        {
            get { return this.guestPaymentInfomation.cOrderID; }
            set { this.guestPaymentInfomation.cOrderID = value; }
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
        [StringLength(4, MinimumLength = 4, ErrorMessage = "卡號為16碼")]
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
        [StringLength(3, MinimumLength = 3, ErrorMessage = "安全碼為3碼")]
        [Required(ErrorMessage = "安全碼不可空白")]
        [DisplayName("安全碼")]
        public Nullable<int> cGuestCreditCardSecurityCode
        {
            get { return this.guestPaymentInfomation.cGuestCreditCardSecurityCode; }
            set { this.guestPaymentInfomation.cGuestCreditCardSecurityCode = value; }
        }
    }
}