using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST3.Models
{
    public class tADFactory
    {
        TESTEntities db = new TESTEntities();

        //圖片儲存位置
        string savePath = "C:/Users/benny/source/repos/TEST3/TEST3/ADImage/";
        //新增圖片
        public void Create(HttpPostedFileBase image, tAD tad)
        {
            //圖片存到ADImage資料夾，檔名為現在時間+廠商名稱+圖片檔名
            string adFileName = DateTime.Now.ToString("yyyyMMdd") + "-" + DateTime.Now.Millisecond + "-" + image.FileName;
            image.SaveAs(savePath + adFileName);

            tAdvertising tAdvertising = new tAdvertising();
            tAdvertising.cADName = image.FileName;
            tAdvertising.cADFileName = adFileName;
            tAdvertising.cADCreateDate = DateTime.Now;
            tAdvertising.cADEditDate = DateTime.Now;
            tAdvertising.cADStartDate = tad.cADStartDate;
            tAdvertising.cADDueDate = tad.cADDueDate;
            tAdvertising.cADActionDate = tad.cADActionDate;
            tAdvertising.cADStatus = true;
            tAdvertising.cADGroup = tad.cADGroup;
            tAdvertising.cADURL = tad.cADURL;

            db.tAdvertising.Add(tAdvertising);
            db.SaveChanges();
        }
        //修改
        public void Update(tAdvertising tAdvertising)
        {
            int sn = tAdvertising.cADSN;
            var q = (from n in db.tAdvertising
                     where n.cADSN == sn
                     select n).First();
            q.cADName = tAdvertising.cADName;
            q.cADEditDate = DateTime.Now;
            q.cADStartDate = tAdvertising.cADStartDate;
            q.cADDueDate = tAdvertising.cADDueDate;
            q.cADStatus = tAdvertising.cADStatus;
            q.cADGroup = tAdvertising.cADGroup;
            q.cADURL = tAdvertising.cADURL;
            db.SaveChanges();

            //專案內的圖片更名(未解決)
            //FileSystem.Rename(savePath+ q.cADName, savePath+tAdvertising.cADName);
        }
        //刪除
        public void Delete(int sn)
        {
            var q = (from n in db.tAdvertising
                     where n.cADSN == sn
                     select n).First();

            db.tAdvertising.Remove(q);
            db.SaveChanges();
        }

        //廣告業面3個參數+搜尋式
        IQueryable<tAdvertising> SelectAdShow()
        {
            var q = from result in db.tAdvertising
                    where result.cADStatus == true &&
                          result.cADGroup == "1"
                    select result;

            return q;
        }
        //1.廣告數量
        public int AdCount()
        {
            //圖片總數            
            return SelectAdShow().Count();
        }
        //2.廣告圖片名
        public string[] AdName()
        {
            string[] adFileName;
            //取出圖片名
            if (AdCount() == 0)
            {
                adFileName = new string[1] { "讚.jpg" };
                return adFileName;
            }
            else
            {
                adFileName = new string[AdCount()];
                int adFileNameCount = 0;
                foreach (var i in SelectAdShow())
                {
                    adFileName[adFileNameCount] = i.cADFileName;
                    adFileNameCount++;
                }
                return adFileName;
            }
        }
        //3.廣告URL
        public string[] AdURL()
        {
            //取出圖片URL
            string[] adURL;
            if (AdCount() == 0)
            {
                adURL = new string[1] { "ADUpload" };
                return adURL;
            }
            else
            {
                adURL = new string[AdCount()];
                int adURLCount = 0;
                foreach (var i in SelectAdShow())
                {
                    adURL[adURLCount] = i.cADURL;
                    adURLCount++;
                }
                return adURL;
            }
        }


        //關鍵字查詢
        public IQueryable<tAdvertising> QueryAll()
        {
            var q = from result in db.tAdvertising
                    select result;

            return q;
        }
        public IQueryable<tAdvertising> QueryByKeyword(string keyword)
        {
            var q = from result in db.tAdvertising
                    where result.cADName.Contains(keyword)
                    select result;

            return q;
        }
        public tAdvertising QueryBySN(int sn)
        {
            var q = (from result in db.tAdvertising
                     where result.cADSN == sn
                     select result).First();

            return q;
        }

        //修改狀態
        public void ChangeStatus(int sn)
        {
            var q = QueryBySN(sn);
            bool status = (bool)q.cADStatus;
            if (status == true)
            {
                q.cADStatus = false;
            }
            else
            {
                q.cADStatus = true;
            }
            db.SaveChanges();
        }

        //取得滿廣告的天數字串
        public string GetFullDateStr()
        {
            DateTime today = DateTime.Now;
            string fullDays = "";
            for (int i = 0; i < 61; i++)
            {
                today.AddDays(i);
                string day = today.ToString("yyyy-MM-dd");

                var dbDays = from n in db.tAdvertising
                             where n.cADStatus == true &&
                                   n.cADActionDate.Contains(day)
                             select n;

                if (dbDays.Count() > 1)
                {
                    fullDays += day + ",";
                }
            }
            if (fullDays != "")
                fullDays.Substring(0, fullDays.Length - 1);
            else
                fullDays = "2000-01-01";

            return fullDays;
        }
    }
}