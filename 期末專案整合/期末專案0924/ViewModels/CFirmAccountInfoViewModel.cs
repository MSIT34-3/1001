using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class CFirmAccountInfoViewModel
    {
        public tFirmAccountInfomation firmAccountInfomation { get; set; }

        public CFirmAccountInfoViewModel() { this.firmAccountInfomation = new tFirmAccountInfomation(); }
        
        [DisplayName("廠商序號")]
        public int cFirmSN
        {
            get { return this.firmAccountInfomation.cFirmSN; }
            set { this.firmAccountInfomation.cFirmSN = value; }
        }

        [DisplayName("廠商名稱")]
        public string cFirmName
        {
            get { return this.firmAccountInfomation.cFirmName; }
            set { this.firmAccountInfomation.cFirmName = value; }
        }

        [DisplayName("統編")]
        public string cFirmTaxID
        {
            get { return this.firmAccountInfomation.cFirmTaxID; }
            set { this.firmAccountInfomation.cFirmTaxID = value; }
        }
                
        //密碼+密碼確認
        [DisplayName("密碼")]
        public string cFirmPWD { get; set; }
        [DisplayName("密碼確認")]
        public string cFirmPWDChk { get; set; }

        //取上面兩個
        public byte[] cFirmPWDHash
        {
            get { return this.firmAccountInfomation.cFirmPWDHash; }
            set { this.firmAccountInfomation.cFirmPWDHash = value; }
        }
        public byte[] cFirmPWDSalt
        {
            get { return this.firmAccountInfomation.cFirmPWDSalt; }
            set { this.firmAccountInfomation.cFirmPWDSalt = value; }
        }

        [DisplayName("建立日期")]
        public Nullable<DateTime> cFirmAccountCreationDate
        {
            get { return this.firmAccountInfomation.cFirmAccountCreationDate; }
            set { this.firmAccountInfomation.cFirmAccountCreationDate = value; }
        }

        [DisplayName("地址")]
        public string cFirmAddress
        {
            get { return this.firmAccountInfomation.cFirmAddress; }
            set { this.firmAccountInfomation.cFirmAddress = value; }
        }

        [DisplayName("負責人")]
        public string cFirmOwner
        {
            get { return this.firmAccountInfomation.cFirmOwner; }
            set { this.firmAccountInfomation.cFirmOwner = value; }
        }

        [DisplayName("Email")]
        public string cFirmEmail
        {
            get { return this.firmAccountInfomation.cFirmEmail; }
            set { this.firmAccountInfomation.cFirmEmail = value; }
        }

        [DisplayName("電話")]
        public string cFirmPhone
        {
            get { return this.firmAccountInfomation.cFirmPhone; }
            set { this.firmAccountInfomation.cFirmPhone = value; }
        }

        [DisplayName("手機")]
        public string cFirmCellphone
        {
            get { return this.firmAccountInfomation.cFirmCellphone; }
            set { this.firmAccountInfomation.cFirmCellphone = value; }
        }
    }
}