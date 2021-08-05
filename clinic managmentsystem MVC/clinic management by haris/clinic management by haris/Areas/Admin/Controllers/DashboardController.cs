using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;

namespace clinic_management_by_haris.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {

        private harispharmacyEntities1 db = new harispharmacyEntities1();
        public ActionResult Index()
        {
            
                if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
                {


                    return View(from o in db.tbl_orders where o.status == "accept" select o);
                }
                else { return RedirectToAction("AdminLogin", "Login"); }

            }
            
         
    }
}

/*

    /////////////////////////////
  if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                 //body
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
//////////////////////////////

*/
