using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class CheckViewModel
    {
        /// <summary>
        /// 目的地
        /// </summary>
        public string destination { get; set; }
        /// <summary>
        /// 幾間房間
        /// </summary>
        public int room { get; set; }
        /// <summary>
        /// 幾個大人
        /// </summary>
        public int adult { get; set; }
        /// <summary>
        /// 幾個小孩
        /// </summary>
        public int children { get; set; }
        /// <summary>
        /// 住房日期
        /// </summary>
        public DateTime checkin { get; set; }
        /// <summary>
        /// 退房日期
        /// </summary>
        public DateTime checkout { get; set; }

        public List<SelectViewModel> selects { get; set; }
    }

    public class SelectViewModel
    {
        /// <summary>
        /// 飯店編號
        /// </summary>
        public int cHotelSN { get; set; }
        /// <summary>
        /// 飯店平均評分
        /// </summary>
        public string cHotelAverageRating { get; set; }
        /// <summary>
        /// 飯店評價人數
        /// </summary>
        public string cHotelRatingOfPeople { get; set; }
        /// <summary>
        /// 飯店名稱
        /// </summary>
        public string cHotelName { get; set; }
        /// <summary>
        /// 飯店英文名稱
        /// </summary>
        public string cHotelNameEN { get; set; }
        /// <summary>
        /// 搜尋房型最低價格
        /// </summary>
        public decimal cHotelRoomTypePrice { get; set; }
        /// <summary>
        /// 飯店照片
        /// </summary>
        public string cHotelInfoPhotoName { get; set; }
        public string cHotelInfoPhotoFileName { get; set; }
        /// <summary>
        /// 飯店位置
        /// </summary>
        public string cHotelCity { get; set; }

        public string cHotelAdress { get; set; }
    }
}