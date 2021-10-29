using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels.Models
{
    public class tHotelInfoFactory
    {
        dbtravelwebEntities db = new dbtravelwebEntities();





        public IQueryable<tHotelInfomation> QueryAll()
        {
            var q = from result in db.tHotelInfomation
                    select result;

            return q;
        }
        public IQueryable<tHotelInfomation> QueryByKeyword(string keyword)
        {
            var q = from result in db.tHotelInfomation
                    where result.cHotelName.Contains(keyword)
                    select result;

            return q;
        }
        public IQueryable<tHotelInfomation> QueryByFirmSN(int firmSN)
        {
            var q = from result in db.tHotelInfomation
                     where result.cFirmSN == firmSN
                     select result;

            return q;
        }
        public tHotelInfomation QueryBySN(int sn)
        {
            var q = (from result in db.tHotelInfomation
                     where result.cFirmSN == sn
                     select result).First();

            return q;
        }
    }
}