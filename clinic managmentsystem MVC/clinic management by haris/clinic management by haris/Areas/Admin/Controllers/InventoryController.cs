using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;
using clinic_management_by_haris.Areas.Admin.Models;
using System.Net;

namespace clinic_management_by_haris.Areas.Admin.Controllers
{

    public class InventoryController : Controller
    {

        private harispharmacyEntities1 db = new harispharmacyEntities1();
        // GET: Admin/Inventory
        public ActionResult AddInventory()
        {
            /////////////////////////////
            if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                ViewBag.products = from m in db.tbl_products orderby m.pid descending select m;
                return View();
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInventory(tbl_inventory inventory, DateTime expdate, String productId)
        {
            /////////////////////////////
            if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {
                    inventory.pid = Convert.ToInt32(productId);
                    inventory.idate = expdate;
                    db.tbl_inventory.Add(inventory);
                    db.SaveChanges();
                    return RedirectToAction("AllInventory");
                }

                return View(inventory);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }





        public ActionResult AllInventory()
        {
            /////////////////////////////
            if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(db.tbl_inventory.ToList());
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
         
        }

        public ActionResult DeleteInventory(int? id)
        {
            /////////////////////////////
            if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {


                    tbl_inventory i = db.tbl_inventory.Find(id);
                    if (i != null)
                    {
                        db.tbl_inventory.Remove(i);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch { }
                    }
                    return RedirectToAction("AllInventory");
                }
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }

         
        public ActionResult UpdateInventoryQuantity(int? id,int quantity)
        {
            /////////////////////////////
            if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                tbl_inventory product = db.tbl_inventory.Find(id);
                product.quantity = quantity;
                db.SaveChanges();

                return RedirectToAction("AllInventory");
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }
    }//classs end
}