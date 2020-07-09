using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestLayout.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuRight()
        {
            List<string> ls = new List<string>();
            ls.Add("Power Tools");
            ls.Add("Air Tools");
            ls.Add("Hand Tools");
            ls.Add("Accessories");
            ls.Add("Workwear");
            ls.Add("Spare Parts");

            return View(ls);
        }
    }
}