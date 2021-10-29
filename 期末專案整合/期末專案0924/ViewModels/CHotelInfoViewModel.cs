using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class CHotelInfoViewModel
    {
        public tHotelInfomation hotelInfomation { get; set; }

        public CHotelInfoViewModel() { this.hotelInfomation = new tHotelInfomation(); }

        [DisplayName("飯店編號")]
        public int cHotelSN
        {
            get { return this.hotelInfomation.cHotelSN; }
            set { this.hotelInfomation.cHotelSN = value; }
        }

        [DisplayName("廠商編號")]
        public int cFirmSN
        {
            get { return this.hotelInfomation.cHotelSN; }
            set { this.hotelInfomation.cHotelSN = value; }
        }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "廠商統一編號為8碼")]
        [Required(ErrorMessage = "廠商統一編號不可空白")]
        [DisplayName("廠商統一編號(8碼)")]
        public string cFirmTaxID
        {
            get { return this.hotelInfomation.cFirmTaxID; }
            set { this.hotelInfomation.cFirmTaxID = value; }
        }

        [Required(ErrorMessage = "飯店名稱不可空白")]
        [DisplayName("飯店名稱")]
        public string cHotelName
        {
            get { return this.hotelInfomation.cHotelName; }
            set { this.hotelInfomation.cHotelName = value; }
        }

        [Required(ErrorMessage = "飯店英文名稱不可空白")]
        [DisplayName("飯店英文名稱")]
        public string cHotelNameEN
        {
            get { return this.hotelInfomation.cHotelNameEN; }
            set { this.hotelInfomation.cHotelNameEN = value; }
        }

        [Required(ErrorMessage = "飯店所在城市不可空白")]
        [DisplayName("飯店所在城市")]
        public string cHotelCity
        {
            get { return this.hotelInfomation.cHotelCity; }
            set { this.hotelInfomation.cHotelCity = value; }
        }

        [DisplayName("飯店地址")]
        public string cHotelAdress
        {
            get { return this.hotelInfomation.cHotelAdress; }
            set { this.hotelInfomation.cHotelAdress = value; }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "飯店成立日期不可空白")]
        [DisplayName("飯店成立日期")]
        public Nullable<DateTime> cHotelCreationDate
        {
            get { return this.hotelInfomation.cHotelCreationDate; }
            set { this.hotelInfomation.cHotelCreationDate = value; }
        }

        [DisplayName("飯店照片名稱")]
        public string cHotelInfoPhotoName
        {
            get { return this.hotelInfomation.cHotelInfoPhotoName; }
            set { this.hotelInfomation.cHotelInfoPhotoName = value; }
        }

        [DisplayName("飯店照片路徑")]
        public string cHotelInfoPhotoFileName
        {
            get { return this.hotelInfomation.cHotelInfoPhotoFileName; }
            set { this.hotelInfomation.cHotelInfoPhotoFileName = value; }
        }

        [StringLength(10, MinimumLength = 8, ErrorMessage = "電話號碼為9-10碼")]
        [Required(ErrorMessage = "飯店電話不可空白")]
        [DisplayName("飯店電話(區碼加電話號碼)")]
        public string cHotelPhone
        {
            get { return this.hotelInfomation.cHotelPhone; }
            set { this.hotelInfomation.cHotelPhone = value; }
        }

        [DisplayName("飯店平均評分")]
        public string cHotelAverageRating
        {
            get { return this.hotelInfomation.cHotelAverageRating; }
            set { this.hotelInfomation.cHotelAverageRating = value; }
        }

        [DisplayName("飯店評價人數")]
        public string cHotelRatingOfPeople
        {
            get { return this.hotelInfomation.cHotelRatingOfPeople; }
            set { this.hotelInfomation.cHotelRatingOfPeople = value; }
        }

        [Required(ErrorMessage = "飯店種類不可空白")]
        [DisplayName("飯店種類")]
        public string cHotelType
        {
            get { return this.hotelInfomation.cHotelType; }
            set { this.hotelInfomation.cHotelType = value; }
        }

        [Required(ErrorMessage = "無障礙友善飯店不可空白")]
        [DisplayName("無障礙友善飯店")]
        public Nullable<bool> cHotelBarrierfree
        {
            get { return this.hotelInfomation.cHotelBarrierfree; }
            set { this.hotelInfomation.cHotelBarrierfree = value; }
        }

        [DisplayName("瀏覽人數")]
        public string cHotelVisitors
        {
            get { return this.hotelInfomation.cHotelVisitors; }
            set { this.hotelInfomation.cHotelVisitors = value; }
        }
    }
}