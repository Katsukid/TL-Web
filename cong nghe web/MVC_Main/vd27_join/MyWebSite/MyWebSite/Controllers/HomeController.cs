using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Footer()
        {
            var ls = new List<Category>();
            for(int i=0;i<5;i++)
            {
                Category cat = new Category();
                cat.id = i;
                cat.name = "Danh muc " + i;
                ls.Add(cat);
            }
            return View(ls);
        }







        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}