﻿using System;
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
        public ActionResult Add()
        {
            return View("Add");
        }
        public ActionResult Delete()
        {
            return View("Delete",new Student{ ID = 1, Name = "Student1", Age=20 });
        }

        public ActionResult Edit()
        {
            return View(new Student { ID = 1, Name = "Student1", Age = 20 });
        }
        public ActionResult Detail()
        {
            return View(new Student { ID = 1, Name = "Student1", Age = 20 });
        }
        public ActionResult Create()
        {
            return View(new Student { ID = 1, Name = "Student1", Age = 20 });
        }
	}
}

