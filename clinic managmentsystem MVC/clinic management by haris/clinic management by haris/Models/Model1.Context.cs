//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clinic_management_by_haris.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class harispharmacyEntities1 : DbContext
    {
        public harispharmacyEntities1()
            : base("name=harispharmacyEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_clientLogin> tbl_clientLogin { get; set; }
        public virtual DbSet<tbl_feedback> tbl_feedback { get; set; }
        public virtual DbSet<tbl_inventory> tbl_inventory { get; set; }
        public virtual DbSet<tbl_orders> tbl_orders { get; set; }
        public virtual DbSet<tbl_products> tbl_products { get; set; }
        public virtual DbSet<tbl_cart> tbl_cart { get; set; }
        public virtual DbSet<emp> emps { get; set; }
    }
}
