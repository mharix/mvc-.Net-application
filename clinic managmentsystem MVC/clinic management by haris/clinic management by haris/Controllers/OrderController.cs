using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Net;

namespace clinic_management_by_haris.Controllers
{
    public class OrderController : Controller
    {
        List<int> i = new List<int>();

        private harispharmacyEntities1 db = new harispharmacyEntities1();
        // GET: Order
        public ActionResult AddToCart(int? id = 0, int? qty = 1)
        {
            tbl_cart ct = db.tbl_cart.Find(id);
            if (ct == null)
            {
                tbl_cart cart = new tbl_cart();
                cart.inventoryid = id;
                cart.quantity = qty;
                db.tbl_cart.Add(cart);
                
            }
            else {
                ct.quantity++;
            }
            
            db.SaveChanges();
             

            return RedirectToAction("Home", "Home");
        }

        

        public ActionResult ShowCart()
        {
            return View( db.tbl_cart.ToList());
        }
        [HttpPost]
        public ActionResult ShowCart(int qty,int itemid)
        {
            tbl_inventory inventory = new tbl_inventory();
            
            tbl_cart ct = db.tbl_cart.Find(itemid);
            inventory = db.tbl_inventory.Find(ct.tbl_inventory.id);
            if (inventory.quantity >= qty)
            {
                ct.quantity = qty;
            }
            db.SaveChanges();
            return View(db.tbl_cart.ToList());
        }
        
        public ActionResult removeCart(int? itemid)
        {
            if (itemid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {


                tbl_cart ct = db.tbl_cart.Find(itemid);
                if (ct != null)
                {
                    db.tbl_cart.Remove(ct);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch { }
                }
            }
                return RedirectToAction("ShowCart");
        }

        [HttpPost]

        public ActionResult PlaceOrder()
        {
            if (Session["cname"] != null && Session["cid"] != null)
            {
                /////////////////////////////////////////////////
                tbl_inventory inventory = new tbl_inventory();
                var items = db.tbl_cart.ToList();
                foreach (var item in items)
                {
                    inventory = db.tbl_inventory.Find(item.inventoryid);
                    inventory.quantity -= item.quantity;
                    tbl_orders order = new tbl_orders();
                    order.pid = item.tbl_inventory.pid;
                    order.quantity = item.quantity;
                    order.inventoryid = item.tbl_inventory.id;
                    order.cid =  Convert.ToInt32(Session["cid"]);
                    order.orderdate = DateTime.Now;
                    db.tbl_orders.Add(order);
                    db.tbl_cart.Remove(item);
                }
                db.SaveChanges();
                //db.tbl_cart.RemoveRange(items);
                return RedirectToAction("Home", "Home");
                //////////////////////////////////////////
            }
            else { return RedirectToAction("ClientLogin", "Home"); }
        }

        

        


    }
}

/*

 if (Session["cname"] != null && Session["cid"] != null)
      {
      //body
     }
            else { return RedirectToAction("ClientLogin", "Home"); }

    */
