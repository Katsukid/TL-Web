using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Entities;

namespace MVCDemo.Dao
{
    public class UserDao
    {
        MyClassDbContext db;
        public UserDao()
        {
            db = new MyClassDbContext();
        }
        public bool Login(string UserName, string Password)
        {
            var rs = db.User.Count(x => x.UserName == UserName && x.Password == Password);
            if (rs > 0)
                return true;
            else
                return false;
        }
    }
}

