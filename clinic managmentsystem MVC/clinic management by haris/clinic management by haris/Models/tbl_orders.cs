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
    using System.Collections.Generic;
    
    public partial class tbl_orders
    {
        public int id { get; set; }
        public Nullable<int> pid { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> cid { get; set; }
        public System.DateTime orderdate { get; set; }
        public string status { get; set; }
        public Nullable<int> inventoryid { get; set; }
    
        public virtual tbl_clientLogin tbl_clientLogin { get; set; }
        public virtual tbl_products tbl_products { get; set; }
        public virtual tbl_inventory tbl_inventory { get; set; }
    }
}
