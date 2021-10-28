using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels.Models
{
    public class tFirmAccountInfoFactory
    {
        dbtravelwebEntities db = new dbtravelwebEntities();
        //新增廠商帳號
        public void Create(CFirmAccountInfoViewModel cFirmAccountInfo)
        {
            string getPWD = cFirmAccountInfo.cFirmPWD;
            byte[] pwHashSalt = null;
            byte[] salt = null;
            PasswordHashAndSalt PWSalt = new PasswordHashAndSalt();
            PWSalt.PasswordHashSalt(getPWD, out pwHashSalt, out salt);

            //還沒加限制
            tFirmAccountInfomation tFirmAccountInfomation = new tFirmAccountInfomation();
            tFirmAccountInfomation.cFirmName = cFirmAccountInfo.cFirmName;
            tFirmAccountInfomation.cFirmTaxID = cFirmAccountInfo.cFirmTaxID;
            tFirmAccountInfomation.cFirmPWDHash = pwHashSalt;
            tFirmAccountInfomation.cFirmPWDSalt = salt;
            tFirmAccountInfomation.cFirmAccountCreationDate = DateTime.Now;
            tFirmAccountInfomation.cFirmAddress = cFirmAccountInfo.cFirmAddress;
            tFirmAccountInfomation.cFirmOwner = cFirmAccountInfo.cFirmOwner;
            tFirmAccountInfomation.cFirmEmail = cFirmAccountInfo.cFirmEmail;
            tFirmAccountInfomation.cFirmPhone = cFirmAccountInfo.cFirmPhone;
            tFirmAccountInfomation.cFirmCellphone = cFirmAccountInfo.cFirmCellphone;
            db.tFirmAccountInfomation.Add(tFirmAccountInfomation);
            db.SaveChanges();
        }

        
        //關鍵字查詢
        internal IQueryable<tFirmAccountInfomation> QueryAll()
        {
            var q = from result in db.tFirmAccountInfomation
                    select result;

            return q;
        }
        internal IQueryable<tFirmAccountInfomation> QueryByKeyword(string keyword)
        {
            var q = from result in db.tFirmAccountInfomation
                    where result.cFirmName.Contains(keyword)||
                          result.cFirmTaxID.Contains(keyword)
                    select result;

            return q;
        }
        public tFirmAccountInfomation QueryBySN(int sn)
        {
            var q = (from result in db.tFirmAccountInfomation
                     where result.cFirmSN == sn
                     select result).First();

            return q;
        }
    }
}