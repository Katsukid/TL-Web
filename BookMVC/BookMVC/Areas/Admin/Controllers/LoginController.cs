using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
using System.Web.Security;
using BookMVC.Areas.Admin.Code;
namespace BookMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
          public ActionResult Index()
          {
               return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(BookMVC.Entities.Admin ad)
          {
               if(Membership.ValidateUser(ad.UserName,ad.PassWord) && ModelState.IsValid)
               {
                    FormsAuthentication.SetAuthCookie(ad.UserName,false);
                    return RedirectToAction("Index", "Home");
               }
               return View();
          }
          public ActionResult Logout()
          {
               FormsAuthentication.SignOut();
               return RedirectToAction("Index", "Login");
          }
    }
}