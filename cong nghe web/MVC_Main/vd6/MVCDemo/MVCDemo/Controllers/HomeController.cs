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

            Account acc = new Account();
            acc.Name = "admin";
            acc.Password = "tav";
            return View(acc);
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
