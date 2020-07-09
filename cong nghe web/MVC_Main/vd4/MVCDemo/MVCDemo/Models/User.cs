using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public CMND cmnd { get; set; }
        public Banglaixe blx { get; set; }
    }
}