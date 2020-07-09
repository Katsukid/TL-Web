using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class MyGroup
    {
        public List<Student> LsStudent { get; set; }
        public List<Teacher> LsTeacher { get; set; }
    }
}