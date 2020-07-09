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
            return View();
        }
        [HttpPost]
        public ActionResult LoginAction()
        {
            string name = Request.Form["name"];
            string password = Request.Form["password"];
            if ("admin".Equals(name) && "tav".Equals(password))
            {
                Session["username"] = name;
                return RedirectToAction("Index","Home");
            }
            return View();
        }

	}
}