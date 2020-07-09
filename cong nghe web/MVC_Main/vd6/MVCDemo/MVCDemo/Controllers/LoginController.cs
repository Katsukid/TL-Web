using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginAction(Account acc)
        {
            ViewBag.Title = acc.Password + "!!";
            return View("Login");
        }

    }
}

