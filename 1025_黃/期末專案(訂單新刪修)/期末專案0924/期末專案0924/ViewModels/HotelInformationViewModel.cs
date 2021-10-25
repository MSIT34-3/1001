using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 期末專案0924.ViewModels
{
    public class HotelInformationViewModel
    {
        public tHotelInfomation hotelInfomation { get; set; } //這裡不太懂
        public HotelInformationViewModel() { this.hotelInfomation = new tHotelInfomation(); }
        public int cHotelSN {
            get { return this.hotelInfomation.cHotelSN; }
            set { this.hotelInfomation.cHotelSN = value; }
        }
        public Nullable<int> cFirmSN {
            get { return this.hotelInfomation.cFirmSN; }
            set { this.hotelInfomation.cFirmSN = value; }
        }
        public Nullable<int> cFirmTaxID {
            get { return this.hotelInfomation.cFirmTaxID; }
            set { this.hotelInfomation.cFirmTaxID = value; }
        }
        [Required(ErrorMessage = "產品名稱不可空白")]
        [DisplayName("旅館名稱")]
        public string cHotelName {
            get { return this.hotelInfomation.cHotelName; }
            set { this.hotelInfomation.cHotelName = value; }
        }
        public string cHotelNameEN {
            get { return this.hotelInfomation.cHotelNameEN; }
            set { this.hotelInfomation.cHotelNameEN = value; }
        }
        public string cHotelCity {
            get { return this.hotelInfomation.cHotelCity; }
            set { this.hotelInfomation.cHotelCity = value; }
        }
        public string cHotelAdress {
            get { return this.hotelInfomation.cHotelAdress; }
            set { this.hotelInfomation.cHotelAdress = value; }
        }
        public Nullable<System.DateTime> cHotelCreationDate {
            get { return this.hotelInfomation.cHotelCreationDate; }
            set { this.hotelInfomation.cHotelCreationDate = value; }
        }
        public byte[] cHotelInfoPhoto {
            get { return this.hotelInfomation.cHotelInfoPhoto; }
            set { this.hotelInfomation.cHotelInfoPhoto = value; }
        }
        public Nullable<double> cHotelAverageRating {
            get { return this.hotelInfomation.cHotelAverageRating; }
            set { this.hotelInfomation.cHotelAverageRating = value; }
        }
        public Nullable<int> cHotelRatingOfPeople {
            get { return this.hotelInfomation.cHotelRatingOfPeople; }
            set { this.hotelInfomation.cHotelRatingOfPeople = value; }
        }
        public string cHotelType {
            get { return this.hotelInfomation.cHotelType; }
            set { this.hotelInfomation.cHotelType = value; }
        }
        public Nullable<bool> cHotelBarrierfree {
            get { return this.hotelInfomation.cHotelBarrierfree; }
            set { this.hotelInfomation.cHotelBarrierfree = value; }
        }
        public string cHotelPhone {
            get { return this.hotelInfomation.cHotelPhone; }
            set { this.hotelInfomation.cHotelPhone = value; }
        }
    }
}