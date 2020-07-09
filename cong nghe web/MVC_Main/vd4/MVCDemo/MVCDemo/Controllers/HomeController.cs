using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["username"]==null)
            {
                return RedirectToAction("Login","Login");
            }
            return View();
        }

        public ActionResult About()
        {

            if (Session["username"] == null)
                return RedirectToAction("Index","Authentication");
            else
            {
                List<User> list = new List<User>();
                for(int i = 0; i < 10; i++)
                {
                    User user = new User();
                    user.username = "abc";
                    list.Add(user);
                }
       

                //taoj ra lisst user
                //for twf dau den cuoi list do
                // so sanh tung phan tu , phan tu nao co usernanem =Session["username"] 
                //Tra ve view cuar about thong tin user do

                return View();
            }
               
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
