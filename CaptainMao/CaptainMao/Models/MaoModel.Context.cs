﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaptainMao.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MaoEntities : DbContext
    {
        public MaoEntities()
            : base("name=MaoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Adoption> Adoptions { get; set; }
        public virtual DbSet<AdpWish> AdpWishes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Citys { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<HospitalCategoryDetail> HospitalCategoryDetails { get; set; }
        public virtual DbSet<StoreInfo> StoreInfoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TitleCategory> TitleCategories { get; set; }
        public virtual DbSet<UserPet> UserPets { get; set; }
        public virtual DbSet<Merchandise> Merchandises { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<shoppingcart> shoppingcarts { get; set; }
        public virtual DbSet<sType> sTypes { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<Scorce> Scorces { get; set; }
    
        public virtual int DeleteToMerchandise_Type_View(Nullable<int> merchandiseID)
        {
            var merchandiseIDParameter = merchandiseID.HasValue ?
                new ObjectParameter("MerchandiseID", merchandiseID) :
                new ObjectParameter("MerchandiseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteToMerchandise_Type_View", merchandiseIDParameter);
        }
    
        public virtual int InsertToMerchandise_Type_View(Nullable<int> merchandiseID, Nullable<int> sTypeID)
        {
            var merchandiseIDParameter = merchandiseID.HasValue ?
                new ObjectParameter("MerchandiseID", merchandiseID) :
                new ObjectParameter("MerchandiseID", typeof(int));
    
            var sTypeIDParameter = sTypeID.HasValue ?
                new ObjectParameter("sTypeID", sTypeID) :
                new ObjectParameter("sTypeID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertToMerchandise_Type_View", merchandiseIDParameter, sTypeIDParameter);
        }
    }
}
