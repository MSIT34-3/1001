using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels.Models
{
    public class GetDates
    {
        public  List<DateTime> GetTwoDates(DateTime beginDate, DateTime endDate)
        {
            int year_Begin = Convert.ToInt32(beginDate.ToString("yyyy"));
            int month_Begin = Convert.ToInt32(beginDate.ToString("MM"));
            int day_Begin = Convert.ToInt32(beginDate.ToString("dd"));
            int year_End = Convert.ToInt32(endDate.ToString("yyyy"));
            int month_End = Convert.ToInt32(endDate.ToString("MM"));
            int day_End = Convert.ToInt32(endDate.ToString("dd"));
            List<DateTime> result = new List<DateTime>();
            for (DateTime dt = new DateTime(year_Begin, month_Begin, day_Begin); dt < new DateTime(year_End, month_End, day_End); dt = dt.AddDays(1))
            {
                string show = dt.ToString("yyyy/MM/dd");
                result.Add(Convert.ToDateTime(show));
            }
            return result;
            //無腦解法
            //DateTime beginDate = DateTime.Parse(textBox1.Text);
            //DateTime endDate = DateTime.Parse(textBox2.Text);

            //int beignyear = Convert.ToInt32(beginDate.Year);
            //int endyear = Convert.ToInt32(endDate.Year);
            //int beignmouth = Convert.ToInt32(beginDate.Year);
            //int endmouth = Convert.ToInt32(endDate.Year);
            //int beignday = Convert.ToInt32(beginDate.Year);
            //int endday = Convert.ToInt32(endDate.Year);

            //for (int i = beignyear; i < endyear + 1; i++)
            //{
            //    for (int j = beignmouth; j < endmouth + 1; j++)
            //    {

            //        for (int k = beignday; k < endday; k++)
            //        {
            //            String show = i + "/" + j + "/" + k;
            //            DateTime showdate = Convert.ToDateTime(show);
            //            List<DateTime> gettwodates = new List<DateTime>();
            //            gettwodates.Add(showdate);
            //        }
            //    }


            //}
        }
    }
}