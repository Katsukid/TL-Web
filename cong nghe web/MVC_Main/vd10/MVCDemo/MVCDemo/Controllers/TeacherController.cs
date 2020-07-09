using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class TeacherController : Controller
    {
        public ActionResult Index()
        {
            return View(Teacher.getAll(6));
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}