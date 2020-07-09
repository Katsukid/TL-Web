using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public static IEnumerable<Student> getAll(int n)
        {
            var st = new List<Student>();
            for(int i=0;i<n;i++)
            {
                Student student = new Student();
                student.id = i;
                student.name = "Student " + i;
                student.age = 20;
                st.Add(student);
            }
            return st;

        }

    }
}