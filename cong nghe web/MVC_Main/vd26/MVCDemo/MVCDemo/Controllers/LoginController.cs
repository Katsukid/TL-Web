using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using MVCDemo.Entities;
using MVCDemo.Dao;

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
            UserDao dao = new UserDao();
            bool check = dao.Login(acc.Name, acc.Password);
            if (check)
            {
                Session["UserName"] = acc.Name;
                return RedirectToAction("Index", "Home");
            }             
            else
                return View("Login");
        }

    }
}

