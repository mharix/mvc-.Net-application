using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clinic_management_by_haris.Models;

namespace clinic_management_by_haris.Areas.Admin.Controllers
{


    public class LoginController : Controller
    {

        private harispharmacyEntities1 db = new harispharmacyEntities1();
        // GET: Admin/Login
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string email, string password)
        {
            var obj = db.tbl_clientLogin.Where(a => a.email.Equals(email) && a.pass.Equals(password)).FirstOrDefault();
            if (obj != null)
            {
                if (obj.name == "muhammad Haris")
                {
                    Session["aname"] = obj.name;
                     
                    return RedirectToAction("Index", "Dashboard");
                }
                else { return RedirectToAction("AdminLogin", "Login"); }
            }
            return View(obj);
        }

        public ActionResult AdminLogout()
        {
            Session["aname"] = "user";
            //Session.Clear();
            //Session.RemoveAll();
            //Session.Abandon();

            return RedirectToAction("AdminLogin", "Login");
        }
    }
}