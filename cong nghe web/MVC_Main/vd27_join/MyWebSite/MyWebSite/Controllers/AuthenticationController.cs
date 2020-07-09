using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebSite.Models;
using MyWebSite.Models.Dao;

namespace MyWebSite.Controllers
{
    public class AuthenticationController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            string username = account.UserName;
            string password = account.Password;
            UserDao dao = new UserDao();
            if(dao.Login(username, password))
            {
                Session["username"] = username;
                return View("Succ");
            }
            else
                return View("Error");
        }
        public ActionResult ProfileDetail()
        {
            return Redirect("/Home/Index");
        }
    }
}