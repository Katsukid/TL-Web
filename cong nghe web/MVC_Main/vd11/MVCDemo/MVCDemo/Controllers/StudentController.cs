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
            List<Student> lsStudent = new List<Student>();

            for (int i = 0; i < 3; i++)
            {
                Student student = new Student();
                student.ID = i;
                student.Name = "student " + i;
                student.Age = i * 2;
                lsStudent.Add(student);
            }

            List<Teacher> ls = new List<Teacher>();
            for (int i=0;i<5;i++)
            {
                Teacher teacher = new Teacher();
                teacher.ID = i;
                teacher.Name = "teacher " + i;
                teacher.Age = i * 2;
                ls.Add(teacher);
            }

            MyGroup group = new MyGroup();
            group.LsStudent = lsStudent;
            group.LsTeacher = ls;

            return View("Test", group);
        }
        public ActionResult Add()
        {
            return View("Add");
        }
	}
}

