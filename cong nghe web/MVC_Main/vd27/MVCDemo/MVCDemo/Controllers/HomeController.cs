using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["UserName"]==null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Account acc = new Account();
                acc.Name = Session["UserName"].ToString();
                acc.Password = "";
                return View(acc);
            }
            
        }

        public ActionResult About()
        {
          //  ViewBag.Message = "Your application description page.";
            Account acc = new Account();
            acc.Name = "Tran Van An";
            acc.Password = "tav";
            return View(acc);
           // return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
