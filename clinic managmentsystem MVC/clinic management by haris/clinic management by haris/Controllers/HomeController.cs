using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;
using System.Data;
using PagedList;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Security;

namespace clinic_management_by_haris.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        private harispharmacyEntities1 db = new harispharmacyEntities1();

        [Authorize(Roles="user")]
        public ActionResult Home()
        {
            return View(db.tbl_inventory.ToList());
        }






        /// <summary> home page actions above
        /// /////////////////////////////////////
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public ActionResult Medicines(string type, int? page, int? pageSize = 12)
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            //Ddefault size is 5 otherwise take pageSize value  
            int defaSize = (pageSize ?? 20);

            ViewBag.psize = defaSize;

            //Dropdownlist code for PageSize selection  
            //In View Attach this  
            ViewBag.PageSize = new List<SelectListItem>()
         {
  new SelectListItem() { Value="5", Text= "5" },
             new SelectListItem() { Value="10", Text= "10" },
             new SelectListItem() { Value="20", Text= "20" },
             new SelectListItem() { Value="40", Text= "40" },
             new SelectListItem() { Value="50", Text= "50" },
         };

            IPagedList<tbl_inventory> medlist = null;

            //Alloting nos. of records as per pagesize and page index.  
            if (type==null) { medlist = (from m in db.tbl_inventory
                               where (m.tbl_products.ptype == "Liquid" || m.tbl_products.ptype == "tablet" || m.tbl_products.ptype == "injection" || m.tbl_products.ptype == "capsule")
                               select m).OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);
            }
            else {
                medlist = (from m in db.tbl_inventory
                           where (m.tbl_products.ptype == type )
                           select m).OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);
            }
            return View(medlist);

        }
         




        public ActionResult Machine(int? page, int? pageSize = 12)
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            //Ddefault size is 5 otherwise take pageSize value  
            int defaSize = (pageSize ?? 20);

            ViewBag.psize = defaSize;

            //Dropdownlist code for PageSize selection  
            //In View Attach this  
            ViewBag.PageSize = new List<SelectListItem>()
         {
              new SelectListItem() { Value="5", Text= "5" },
             new SelectListItem() { Value="10", Text= "10" },
             new SelectListItem() { Value="20", Text= "20" },
             new SelectListItem() { Value="40", Text= "40" },
             new SelectListItem() { Value="50", Text= "50" },
         };

            IPagedList<tbl_inventory> medlist = null;

            //Alloting nos. of records as per pagesize and page index.  
           // medlist = db.tbl_inventory.OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);
            medlist = (from m in db.tbl_inventory
                       where (m.tbl_products.ptype == "apparatus")
                       select m).OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);
            //medlist = from m in db.tbl_products orderby m.pid descending select m;
            return View(medlist);

        }

        public ActionResult Education(string type,int? page, int? pageSize = 12)
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;


            //Ddefault size is 5 otherwise take pageSize value  
            int defaSize = (pageSize ?? 20);

            ViewBag.psize = defaSize;

            //Dropdownlist code for PageSize selection  
            //In View Attach this  
            ViewBag.PageSize = new List<SelectListItem>()
         {
             new SelectListItem() { Value="5", Text= "5" },
             new SelectListItem() { Value="10", Text= "10" },
             new SelectListItem() { Value="20", Text= "20" },
             new SelectListItem() { Value="40", Text= "40" },
             new SelectListItem() { Value="50", Text= "50" },
         };

            IPagedList<tbl_inventory> medlist = null;

            //Alloting nos. of records as per pagesize and page index.  
            if (type == null)
            {
                medlist = (from m in db.tbl_inventory
                           where (m.tbl_products.ptype == "Paractical" || m.tbl_products.ptype == "Seminar" || m.tbl_products.ptype == "Lecture")
                           select m).OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);

            }
            else {
                medlist = (from m in db.tbl_inventory
                           where (m.tbl_products.ptype == type)
                           select m).OrderBy(x => x.pid).ToPagedList(pageIndex, defaSize);

            }

            return View(medlist);

        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(string name,string email,string phone,string message)
        {
            tbl_feedback feed = new tbl_feedback(); ;
            feed.name = name;
            feed.email = email;
            feed.phone = phone;
            feed.comments = message;
            db.tbl_feedback.Add(feed);

            db.SaveChanges();

            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ClientLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClientLogin(string email,string password)
        {
            var obj = db.tbl_clientLogin.Where(a => a.email.Equals(email) && a.pass.Equals(password)).FirstOrDefault();
            if (obj != null)
            {
                Session["cname"] = obj.name.ToString(); Session["cid"] =obj.cid.ToString();
                

                return RedirectToAction("Home");
            }
            return View(obj);
        }

        public ActionResult ClientRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ClientRegister(string name, string email,string password, string phone, string address)
        {
            tbl_clientLogin reg = new tbl_clientLogin();
            reg.name = name;
            reg.email = email;
            reg.pass = password;
            reg.phone = phone;
            reg.caddress = address;
            db.tbl_clientLogin.Add(reg);

            db.SaveChanges();

            return RedirectToAction("ClientLogin");
        }


        public ActionResult Logout()
        {
            Session["cname"] = null; Session["cid"] = null;
            return RedirectToAction("ClientLogin");
        }


        public ActionResult ProductDetails(int id)
        {
            tbl_inventory p = new tbl_inventory();
            p = db.tbl_inventory.Find(id);
            if (p != null)
            {
                ViewBag.name = p.tbl_products.pname;
                ViewBag.price = p.tbl_products.price.ToString();
                ViewBag.image = p.tbl_products.pimage;
                ViewBag.quantity = p.quantity;
                ViewBag.itemid = p.id;
                ViewBag.type = p.tbl_products.ptype;
                ViewBag.code = p.tbl_products.pcode;
                ViewBag.description = p.tbl_products.pdescription;
            }
           
            return View();
        }
    }
}