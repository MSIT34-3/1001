using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專題_旅遊網.ViewModels.Models
{
    public class HomeLoginFactory
    {
        dbtravelwebEntities db = new dbtravelwebEntities();

        //確認帳號密碼正確+確認身分
        public CHomeLoginViewModel Identify(CHomeLoginViewModel login)
        {
            string email = login.inputEmail;
            string pWD = login.inputPWD;
            CHomeLoginViewModel output = new CHomeLoginViewModel();
            output.identity = 0;

            if (email != null && pWD != null)
            {
                ////旅客 1
                var e1 = (from n in db.tGuestAccountInfomation
                          where n.cGuestEmail == email
                          select n).FirstOrDefault();
                if (e1 != null && e1.cGuestPWDHash == pWD)
                {
                    output.Guestsn = e1.cGuestSN;
                    output.name = e1.cGuestLastName;
                    output.identity = 1;
                    return output;
                }

                //廠商 2
                var e2 = (from n in db.tFirmAccountInfomation
                          where n.cFirmEmail == email
                          select n).FirstOrDefault();
                if (e2 != null)
                {
                    PasswordHashAndSalt PW = new PasswordHashAndSalt();
                    byte[] pWDHashFromUser = PW.CheckPassword(pWD, e2.cFirmPWDSalt);
                    if (pWDHashFromUser.SequenceEqual(e2.cFirmPWDHash))
                    {
                        output.sn = e2.cFirmSN;
                        output.name = e2.cFirmName;
                        output.identity = 2;
                        return output;
                    }
                }

                //員工 3
                var e3 = (from n in db.tStaffProfile
                          where n.cStaffAccountID == email
                          select n).FirstOrDefault();
                if(e3!=null &&e3.cStaffPWD==pWD)
                {
                    output.sn = e3.cStaffProfileSN;
                    output.name = "管理員001";
                    output.identity = 3;
                    return output;
                }

                //帳號or密碼錯誤
                return output;
            }
            return output;
        }
    }
}