﻿//------------------------------------------------------------------------------
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
    
        public virtual DbSet<tHotelInfomation> tHotelInfomation { get; set; }
        public virtual DbSet<tUserOrder> tUserOrder { get; set; }
        public virtual DbSet<tHotelOrderSystem> tHotelOrderSystem { get; set; }
        public virtual DbSet<tHotelRoomType> tHotelRoomType { get; set; }
        public virtual DbSet<tGuestPaymentInfomation> tGuestPaymentInfomation { get; set; }
    }
}
