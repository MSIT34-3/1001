//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 期末專案0924
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbtravelwebEntities : DbContext
    {
        public dbtravelwebEntities()
            : base("name=dbtravelwebEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tAdvertising> tAdvertising { get; set; }
        public virtual DbSet<tCreditCardTypeTable> tCreditCardTypeTable { get; set; }
        public virtual DbSet<tCurrency> tCurrency { get; set; }
        public virtual DbSet<tFirmAccountInfomation> tFirmAccountInfomation { get; set; }
        public virtual DbSet<tGuestAccountInfomation> tGuestAccountInfomation { get; set; }
        public virtual DbSet<tGuestCollection> tGuestCollection { get; set; }
        public virtual DbSet<tGuestPaymentInfomation> tGuestPaymentInfomation { get; set; }
        public virtual DbSet<tGuestPreference> tGuestPreference { get; set; }
        public virtual DbSet<tGuestReviews> tGuestReviews { get; set; }
        public virtual DbSet<tHotelActivityManage> tHotelActivityManage { get; set; }
        public virtual DbSet<tHotelCityForm> tHotelCityForm { get; set; }
        public virtual DbSet<tHotelFacilityForm> tHotelFacilityForm { get; set; }
        public virtual DbSet<tHotelFacilityStandardForm> tHotelFacilityStandardForm { get; set; }
        public virtual DbSet<tHotelOrderSystem> tHotelOrderSystem { get; set; }
        public virtual DbSet<tHotelPhoto> tHotelPhoto { get; set; }
        public virtual DbSet<tHotelRoomFacility> tHotelRoomFacility { get; set; }
        public virtual DbSet<tHotelRoomPhoto> tHotelRoomPhoto { get; set; }
        public virtual DbSet<tHotelRoomType> tHotelRoomType { get; set; }
        public virtual DbSet<tHotelTownForm> tHotelTownForm { get; set; }
        public virtual DbSet<tHotelTypeForm> tHotelTypeForm { get; set; }
        public virtual DbSet<tJobTable> tJobTable { get; set; }
        public virtual DbSet<tLanguage> tLanguage { get; set; }
        public virtual DbSet<tManagementAuthority> tManagementAuthority { get; set; }
        public virtual DbSet<tRoomFacilityStandardForm> tRoomFacilityStandardForm { get; set; }
        public virtual DbSet<tStaffProfile> tStaffProfile { get; set; }
        public virtual DbSet<tUserOrder> tUserOrder { get; set; }
        public virtual DbSet<tHotelInfomation> tHotelInfomation { get; set; }
    }
}
