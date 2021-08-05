using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;
using System.Net;

namespace clinic_management_by_haris.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {

        private harispharmacyEntities1 db = new harispharmacyEntities1();
        // GET: Admin/Reports
        public ActionResult ClientList()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(db.tbl_clientLogin.ToList());
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }

        public ActionResult Feedbacks()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(from f in db.tbl_feedback where f.status != "read" select f);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }

       public ActionResult updateFeedback(int? id)
        {
            tbl_feedback fb = db.tbl_feedback.Find(id);
            fb.status = "read";
            db.SaveChanges();
            return RedirectToAction("Feedbacks");
        }


        public ActionResult Orders()
        {
            /////////////////////////////
            if (Session["aname"] != null && Session["aname"].ToString() == "muhammad Haris".ToString())
            {
                return View(from o in db.tbl_orders where o.status != "accept" select o);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           }


        public ActionResult updateOrders(int? id)
        {
            tbl_orders ord = db.tbl_orders.Find(id);
            ord.status = "accept";
            db.SaveChanges();
            return RedirectToAction("Orders");
        }


        public ActionResult CancleOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {

                tbl_orders ord = db.tbl_orders.Find(id);
                if (ord != null)
                {
                    tbl_inventory inventory = new tbl_inventory();
                    inventory = db.tbl_inventory.Find(ord.inventoryid);
                    inventory.quantity +=ord.quantity;
                    db.tbl_orders.Remove(ord);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch { }
                }

                return RedirectToAction("Orders", "Reports");
            }
            
        }

        public ActionResult AcceptOrder(int? id)
        {
          
                return RedirectToAction("Orders", "Reports");
             
            
        }

        
        public ActionResult Medtransactions()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(db.tbl_orders.ToList());
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           

        }

        public ActionResult Apptransactions()
        {

            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(db.tbl_orders.ToList());
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }

        public ActionResult Edutransactions()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(db.tbl_orders.ToList());
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////

         
        }


    }
}