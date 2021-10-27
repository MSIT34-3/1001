using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class PaymentModel
    {
        public tGuestPaymentInfomation GuestPaymentInfomation { get; set; }
        public PaymentModel() { this.GuestPaymentInfomation = new tGuestPaymentInfomation(); }
        [DisplayName("信用卡類型")]
        public string cCreditCardType
        {
            get { return this.GuestPaymentInfomation.cCreditCardType; }
            set { this.GuestPaymentInfomation.cCreditCardType = value; }
        }
        [DisplayName("持卡人生日")]
        public System.DateTime? cGuestCreditCardBirth
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardBirth; }
            set { this.GuestPaymentInfomation.cGuestCreditCardBirth = value; }
        }
        [DisplayName("有效期限(月)")]
        public int? cGuestCreditCardDeadlineMonth
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardDeadlineMonth; }
            set { this.GuestPaymentInfomation.cGuestCreditCardDeadlineMonth = value; }
        }
        [DisplayName("有效期限(年)")]
        public int? cGuestCreditCardDeadlineYear
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardDeadlineYear; }
            set { this.GuestPaymentInfomation.cGuestCreditCardDeadlineYear = value; }
        }
        [DisplayName("持卡人姓名")]
        public string cGuestCreditCardName
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardName; }
            set { this.GuestPaymentInfomation.cGuestCreditCardName = value; }
        }
        [DisplayName("身份證字號")]
        public string cGuestCreditCardNameID
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardNameID; }
            set { this.GuestPaymentInfomation.cGuestCreditCardNameID = value; }
        }
        [DisplayName("信用卡卡號")]
        public string cGuestCreditCardNumber
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardNumber; }
            set { this.GuestPaymentInfomation.cGuestCreditCardNumber = value; }
        }
        [DisplayName("安全碼")]
        public Nullable<int> cGuestCreditCardSecurityCode
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardSecurityCode; }
            set { this.GuestPaymentInfomation.cGuestCreditCardSecurityCode = value; }
        }

    }
}