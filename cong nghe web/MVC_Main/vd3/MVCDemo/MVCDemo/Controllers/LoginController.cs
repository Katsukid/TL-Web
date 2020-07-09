using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Login()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            if (name.Equals("admin") && password.Equals("tav"))
            {
                Session["username"] = name;
                return RedirectToAction("Index","Home");
            }
            return View();
        }

	}
}