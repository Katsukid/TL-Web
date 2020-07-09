using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index()
        {

            var group = new Group {Students=Student.GetList(5), Teachers=Teacher.GetList(5)};
            return View("List", group);
        }
        public ActionResult Test()
        {
            return View("Test", Student.GetList(5));
        }
        public ActionResult Add()
        {
            return View();
        }


    }
}

