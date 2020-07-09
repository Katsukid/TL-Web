using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult Test()
        {
            return View();
        }
        public PartialViewResult MyPartial()
        {
            var list = new List<Category>();
            for(int i=0;i<5;i++)
            {
                Category cat = new Category();
                cat.id = i;
                cat.name="Category "+i;
                list.Add(cat);
            }

            return PartialView(list);
        }
    }
}