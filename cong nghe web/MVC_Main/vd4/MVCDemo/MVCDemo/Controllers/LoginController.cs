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
            Account account = new Account();
            account.UserName = "tavistu";
            account.Email = "tav@gmail.com";
            account.Password = "xyz";

            TempData["account"] = account;
            TempData["quantri"] = "Tran Van An";
            TempData["tuoi"] = 33;
            TempData["ngayhientai"] = DateTime.Now;

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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            //return View();
        }

	}
}