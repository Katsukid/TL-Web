using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
using BookMVC.Dao;
using BookMVC.Areas.Admin.Code;
using System.Web.Security;

namespace BookMVC.Controllers
{
    public class UserController : Controller
    {
          BookMVCDbContext db;
          // GET: User
          public ActionResult Index()
          {
               return View();
          }
          public ActionResult LoginModal()
          {
               return PartialView();
          }
          
          public ActionResult Login()
          {
               return View();
          }
          //[HttpPost]
          //[ValidateAntiForgeryToken]
          //public ActionResult Login(User acc)
          //{
          //     if (Membership.ValidateUser(acc.Email,acc.Password))
          //     {
          //          var us = new UserDao().TakeUser(acc.Email, acc.Password);
          //          FormsAuthentication.SetAuthCookie(us.UserName, acc.RememberMe );
          //          Session["UserName"] = HttpContext.Request.ServerVariables["AUTH_USER"]; // Lay ten dang nhap
          //          Session["UserID"] = us.ID;
          //          return RedirectToAction("Index", "Home");
          //     }
          //     TempData["message"] = "Login Fail";
          //     return RedirectToAction("Index","Home");
          //}
          [HttpPost]
          [ValidateAntiForgeryToken]
          public JsonResult Login(User acc)
          {
               if (Membership.ValidateUser(acc.Email, acc.Password))
               {
                    var us = new UserDao().TakeUser(acc.Email, acc.Password);
                    us.RememberMe = acc.RememberMe;
                    FormsAuthentication.SetAuthCookie(us.UserName, acc.RememberMe);
                    //HttpContext.Request.ServerVariables["AUTH_USER"]
                    Session["UserName"] = us.UserName; // Lay ten dang nhap
                    Session["UserID"] = us.ID;
                    return Json(new
                    {
                         username = us.UserName,
                         status = us.Status
                    });
               }
               return Json(new { check = false });
          }
          public ActionResult Logout()
          {
               FormsAuthentication.SignOut();
               Session.Clear();
               //Session["UserName"] = null;
               //Session["UserID"] = null;
               //Session["Cart"] = null;
               return RedirectToAction("Index", "Home");
          }
          public ActionResult Register()
          {
               return View();
          }
          [HttpPost]
          public ActionResult Register(User us)
          {
               db = new BookMVCDbContext();
               var log = new UserDao();
               {
                    if (ModelState.IsValid)
                    {
                         if (!log.ValidEmail(us.Email)){
                              setAlert("Email không hợp lệ hoặc không tồn tại!","Error");
                         }
                         else if (log.ExistedEmail(us.Email))
                         {
                              setAlert("Email đã được sử dụng bởi tài khoản khác!", "Error");
                         }
                         else
                         {
                              var res = log.AddUser(us);
                              if (res)
                              {
                                   setAlert("Đăng ký thành công!", "success");
                                   return Redirect("/");
                              }
                              else
                              {
                                   setAlert("Đăng ký không thành công! Quý khác vui lòng đăng ký lại", "error");
                                   return RedirectToAction("Register","User");
                              }
                         }
                    }
               }
               return Register();
          }
          // Canh bao nguoi dung
          public void setAlert(string message, string type)
          {
               TempData["AlertMessage"] = message;
               if (type == "success")
               {
                    TempData["AlertType"] = "alert-success";
               }
               else if (type == "error")
               {
                    TempData["AlertType"] = "alert-danger";
               }
          }
          [HttpPost]
          public JsonResult ChangeStatus(long id)
          {
               var result = new UserDao().ChangeStatus(id);
               return Json(new
               {
                    status = result
               });
          }
     }
}