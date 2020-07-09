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

            Teacher teacher = new Teacher();
            teacher.name = "Anton";
            List<Teacher> ls = new List<Teacher>();
            ls.Add(teacher);
            ViewBag.ls = ls;
            return View("List");
        }
        public ActionResult Add()
        {
            return View("Add");
        }
	}
}

