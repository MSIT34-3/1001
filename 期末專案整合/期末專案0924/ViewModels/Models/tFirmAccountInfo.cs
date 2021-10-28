using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels.Models
{
    //原始
    public class tFirmAccountInfo
    {
        public int cFirmSN { get; set; }
        public string cFirmTaxID { get; set; }
        public string cFirmPWD { get; set; }
        public string cFirmPWDChk { get; set; }
        public byte[] cFirmPWDHash { get; set; }
        public byte[] cFirmPWDSalt { get; set; }
        public DateTime cFirmAccountCreationDate { get; set; }
        public string cFirmName { get; set; }
        public string cFirmAddress { get; set; }
        public string cFirmOwner { get; set; }
        public string cFirmEmail { get; set; }
        public string cFirmPhone { get; set; }
        public string cFirmCellphone { get; set; }
    }
}