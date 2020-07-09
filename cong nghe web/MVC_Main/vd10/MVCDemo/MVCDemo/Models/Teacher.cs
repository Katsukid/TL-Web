using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public static List<Teacher> getAll(int n)
        {
            List<Teacher> ls = new List<Teacher>();
            for(int i=0;i<n;i++)
            {
                Teacher tch = new Teacher();
                tch.id = i + 1;
                tch.name = "Teacher " + (i + 1);
                tch.email = "Email " + (i + 1);
                ls.Add(tch);
            }
            return ls;
       
        }
    }
}