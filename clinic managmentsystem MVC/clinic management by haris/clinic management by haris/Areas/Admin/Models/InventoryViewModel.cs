using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace clinic_management_by_haris.Areas.Admin.Models
{
    public class InventoryViewModel
    {
        public int pid { get; set; }
        //name
        public string productname{ get; set; }
        public string producttype { get; set; }
        //quantity
        public int quantity{ get; set; }
        //expirydate
        public DateTime expirydate { get; set; }
        //image
        public String image { get; set; }
    }
}