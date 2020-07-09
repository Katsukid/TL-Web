using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View(ProductData.GetProduct(10));
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}