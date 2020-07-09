using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMVC.Controllers
{
    public class BookByCategoryController : Controller
    {
        // GET: BookByCategory
        public ActionResult NewBook()
        {
            return View();
        }
    }
}