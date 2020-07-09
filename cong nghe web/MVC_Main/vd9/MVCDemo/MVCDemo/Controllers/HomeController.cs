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

            TempData["Mes"] = "Xin chao!";
            TempData["Time"] = DateTime.Now; 
            return RedirectToAction("About");
        }


        public ActionResult About()
        {
            ViewBag.Message = TempData["Mes"]; 
            ViewBag.Date = TempData["Time"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
