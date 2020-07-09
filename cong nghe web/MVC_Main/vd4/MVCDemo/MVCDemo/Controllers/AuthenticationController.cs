using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Detail()
        {
            User user = new User();
            user.password = "123";
            user.username = "tavistu";
            CMND cmnd = new CMND();

            cmnd.so = "1234567890";
            cmnd.diachi="Ha Noi";
            user.cmnd = cmnd;

            Banglaixe blx = new Banglaixe();


            blx.noicap = "TH";
            blx.so = "123456789";
            user.blx = blx;

            TempData["abc"] = user;
            TempData["xyz"] = 123;
            TempData["keke"] = "Haha";

            return View();
        }

        public ActionResult Index()
        {   if(Session["username"] != null)
            {
                return RedirectToAction("About", "Home");
            }
            else
            return View();
        }

 
        [HttpPost]
        public ActionResult Test()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            if ("admin".Equals(username) && "tav".Equals(password))
            {
                Session["username"] = username;
                return RedirectToAction("About", "Home");
            }   
            else
                return RedirectToAction("Index", "Authentication");

        }
    }
}