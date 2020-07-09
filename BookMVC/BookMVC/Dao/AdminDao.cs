using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
namespace BookMVC.Dao
{
     public class AdminDao
     {
          BookMVCDbContext db;
          public AdminDao()
          {
               db = new BookMVCDbContext();
          }
          public bool Login(string UserName, string Password)
          {
               var rs = db.Admins.Count(x => x.UserName == UserName && x.PassWord == Password);
               if (rs > 0)
                    return true;
               return false;
          }
     }
}