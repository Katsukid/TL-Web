using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class StudentData
    {
        public static List<Student> GetListStudent(int count)
        {
            List<Student> list = new List<Student>();
            for(int i = 0;  i< count; i++)
            {
                Student student = new Student();
                student.Id = i;
                student.Age = 20 + i;
                student.Name = "Sinh vien " + i;
                list.Add(student);
            }
            return list;
        }
    }
}