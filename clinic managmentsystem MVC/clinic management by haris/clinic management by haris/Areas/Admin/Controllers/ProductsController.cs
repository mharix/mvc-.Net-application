using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;
using System.IO;
using System.Net;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace clinic_management_by_haris.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {

        private harispharmacyEntities1 db =new harispharmacyEntities1();

     
     

        // GET: Admin/Products
        public ActionResult AddMedicines()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View();
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedicines(tbl_products medicine, HttpPostedFileBase file,String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {
                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            medicine.pimage = name;
                        }
                    }
                    catch
                    {
                        medicine.pimage = "noimage.jpg";
                    }

                    medicine.pdescription = description;


                    db.tbl_products.Add(medicine);
                    db.SaveChanges();
                    return RedirectToAction("AllMedicines");
                }

                return View(medicine);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            }
        
            public ActionResult DeleteMedicine(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {


                    tbl_products med = db.tbl_products.Find(id);
                    if (med != null)
                    {
                        db.tbl_products.Remove(med);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch { }
                    }

                    return RedirectToAction("AllMedicines");

                }
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }

        
          public ActionResult EditMedicine(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                tbl_products product = db.tbl_products.Find(id);

                ViewBag.descript = product.pdescription.ToString();
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////

            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMedicine(tbl_products product, HttpPostedFileBase file, String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {

                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            product.pimage = name;
                        }
                    }
                    catch
                    {
                        product.pimage = "noimage.jpg";
                    }
                    product.pdescription = description;
                    db.Entry(product).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("AllMedicines");
                }
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
             }



        public ActionResult AllMedicines()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(from m in db.tbl_products where (m.ptype == "Liquid" || m.ptype == "tablet" || m.ptype == "injection" || m.ptype == "capsule") select m);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }




/// <summary>
/// ///apparatus actions
/// </summary>
/// <returns></returns>

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        
        public ActionResult AddApparatus()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View();
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddApparatus(tbl_products apparatus, HttpPostedFileBase file, String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {
                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            apparatus.pimage = name;
                        }
                    }
                    catch
                    {
                        apparatus.pimage = "noimage.jpg";
                    }

                    apparatus.pdescription = description;
                    apparatus.ptype = "apparatus";


                    db.tbl_products.Add(apparatus);
                    db.SaveChanges();
                    return RedirectToAction("AllApparatus");
                }

                return View(apparatus);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }

        public ActionResult AllApparatus()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(from m in db.tbl_products where (m.ptype == "apparatus") select m);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
          }

        public ActionResult EditApparatus(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                tbl_products product = db.tbl_products.Find(id);
                ViewBag.descript = product.pdescription.ToString();
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditApparatus(tbl_products product, HttpPostedFileBase file, String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {

                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            product.pimage = name;
                        }
                    }
                    catch
                    {
                        product.pimage = "noimage.jpg";
                    }
                    product.pdescription = description;
                    product.ptype = "apparatus";
                    db.Entry(product).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("AllApparatus");
                }
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }



        public ActionResult DeleteApparatus(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {


                    tbl_products med = db.tbl_products.Find(id);
                    if (med != null)
                    {
                        db.tbl_products.Remove(med);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch { }
                    }

                    return RedirectToAction("AllApparatus");

                }
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }




        /// <summary>
        /// ///education actions
        /// </summary>
        /// <returns></returns>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public ActionResult AddEducation()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View();
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
          
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEducation(tbl_products apparatus, HttpPostedFileBase file, String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {
                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            apparatus.pimage = name;
                        }
                    }
                    catch
                    {
                        apparatus.pimage = "noimage.jpg";
                    }

                    apparatus.pdescription = description;
                    db.tbl_products.Add(apparatus);
                    db.SaveChanges();
                    return RedirectToAction("AllEducation");
                }

                return View(apparatus);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
            
        }

        public ActionResult AllEducation()
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                return View(from m in db.tbl_products where (m.ptype == "Lecture" || m.ptype == "Seminar" || m.ptype == "Paractical") select m);

            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
          }

        public ActionResult EditEducation(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                tbl_products product = db.tbl_products.Find(id);
                ViewBag.descript = product.pdescription.ToString();
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
         
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducation(tbl_products product, HttpPostedFileBase file, String description)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (ModelState.IsValid)
                {

                    string name;
                    try
                    {
                        if (file.ContentLength > 0)
                        {

                            name = file.FileName;
                            string path = Server.MapPath("~/productImages/");
                            string fullpath = Path.Combine(path, name);
                            file.SaveAs(fullpath);
                            product.pimage = name;
                        }
                    }
                    catch
                    {
                        product.pimage = "noimage.jpg";
                    }
                    product.pdescription = description;

                    db.Entry(product).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("AllEducation");
                }
                return View(product);
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }



        public ActionResult DeleteEducation(int? id)
        {
            /////////////////////////////
          if (Session["aname"]!=null && Session["aname"].ToString() =="muhammad Haris".ToString() )
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {


                    tbl_products med = db.tbl_products.Find(id);
                    if (med != null)
                    {
                        db.tbl_products.Remove(med);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch { }
                    }

                    return RedirectToAction("AllEducation");

                }
            }
            else { return RedirectToAction("AdminLogin", "Login"); }
            //////////////////////////////
           
        }


        //action for print ing messeges




    }//namspace end
}
