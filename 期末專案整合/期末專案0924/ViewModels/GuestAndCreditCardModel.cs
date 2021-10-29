using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class GuestAndCreditCardModel
    {
        public tGuestAccountInfomation GuestAccountInfomation { get; set; }
        public tGuestPaymentInfomation GuestPaymentInfomation { get; set; }
        public GuestAndCreditCardModel() { this.GuestAccountInfomation = new tGuestAccountInfomation(); this.GuestPaymentInfomation = new tGuestPaymentInfomation(); }

        [DisplayName("旅客編號")]
        public int cGuestSN
        {
            get { return this.GuestAccountInfomation.cGuestSN; }
            set { this.GuestAccountInfomation.cGuestSN = value; }
        }

        [DisplayName("旅客電子信箱")]
        public string cGuestEmail
        {
            get { return this.GuestAccountInfomation.cGuestEmail; }
            set { this.GuestAccountInfomation.cGuestEmail = value; }
        }
        [DisplayName("旅客密碼HASH")]
        public string cGuestPWDHash
        {
            get { return this.GuestAccountInfomation.cGuestPWDHash; }
            set { this.GuestAccountInfomation.cGuestPWDHash = value; }
        }
        [DisplayName("旅客密碼SALT")]
        public string cGuestPWDSalt
        {
            get { return this.GuestAccountInfomation.cGuestPWDSalt; }
            set { this.GuestAccountInfomation.cGuestPWDSalt = value; }
        }
        [DisplayName("旅客帳號創建日期")]
        public DateTime cGuestAccountCreationDate
        {
            get { return (DateTime)this.GuestAccountInfomation.cGuestAccountCreationDate; }
            set { this.GuestAccountInfomation.cGuestAccountCreationDate = value; }
        }
        [DisplayName("旅客姓氏")]
        public string cGuestLastName
        {
            get { return this.GuestAccountInfomation.cGuestLastName; }
            set { this.GuestAccountInfomation.cGuestLastName = value; }
        }
        [DisplayName("旅客名字")]
        public string cGuestFirstName
        {
            get { return this.GuestAccountInfomation.cGuestFirstName; }
            set { this.GuestAccountInfomation.cGuestFirstName = value; }
        }
        [DisplayName("旅客姓氏(英文)")]
        public string cGuestLastNameEN
        {
            get { return this.GuestAccountInfomation.cGuestLastNameEN; }
            set { this.GuestAccountInfomation.cGuestLastNameEN = value; }
        }
        [DisplayName("旅客名字(英文)")]
        public string cGuestFirstNameEN
        {
            get { return this.GuestAccountInfomation.cGuestFirstNameEN; }
            set { this.GuestAccountInfomation.cGuestFirstNameEN = value; }
        }
        [DisplayName("旅客生日")]
        public DateTime cGuestBirth
        {
            get { return this.GuestAccountInfomation.cGuestBirth; }
            set { this.GuestAccountInfomation.cGuestBirth = value; }
        }
        [DisplayName("旅客國籍")]
        public string cGuestCitizenship
        {
            get { return this.GuestAccountInfomation.cGuestCitizenship; }
            set { this.GuestAccountInfomation.cGuestCitizenship = value; }
        }
        [DisplayName("旅客身份證字號")]
        public string cGuestID
        {
            get { return this.GuestAccountInfomation.cGuestID; }
            set { this.GuestAccountInfomation.cGuestID = value; }
        }
        [DisplayName("旅客性別")]
        public string cGuestGender
        {
            get { return this.GuestAccountInfomation.cGuestGender; }
            set { this.GuestAccountInfomation.cGuestGender = value; }
        }
        [DisplayName("旅客手機號碼")]
        public int cGuestPhoneNumber
        {
            get { return this.GuestAccountInfomation.cGuestPhoneNumber; }
            set { this.GuestAccountInfomation.cGuestPhoneNumber = value; }
        }
        [DisplayName("信用卡類型")]
        public string cCreditCardType
        {
            get { return this.GuestPaymentInfomation.cCreditCardType; }
            set { this.GuestPaymentInfomation.cCreditCardType = value; }
        }
        [DisplayName("信用卡卡號")]
        public string cGuestCreditCardNumber
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardNumber; }
            set { this.GuestPaymentInfomation.cGuestCreditCardNumber = value; }
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
        [DisplayName("安全碼")]
        public int? cGuestCreditCardSecurityCode
        {
            get { return this.GuestPaymentInfomation.cGuestCreditCardSecurityCode; }
            set { this.GuestPaymentInfomation.cGuestCreditCardSecurityCode = value; }
        }
    }
}