using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static IEnumerable<Teacher> GetList(int Count)
        {
            var st = new List<Teacher>();
            for (int i = 1; i <= Count; i++)
            {
                st.Add(new Teacher { ID = i, Name = "Teacher" + i.ToString(), Age = 20 });
            }
            return st;
        }
    }
}