using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
using System.Collections.Specialized;
using System.Net;
using System.Text;
namespace BookMVC.Dao
{
     public class UserDao
     {
          BookMVCDbContext db;
          public UserDao()
          {
               db = new BookMVCDbContext();
          }
          public bool Login(string Email, string Password)
          {
               var rs = db.Users.Count(x => x.Email == Email && x.Password == Password);
               if (rs > 0)
                    return true;
               return false;
          }
          public User TakeUser(string EMAIL, string PASSWORD)
          {
               return db.Users.Where(x => x.Email == EMAIL && x.Password == PASSWORD).SingleOrDefault();
          }
          // Lay tai khoan bang ID
          public User GetUser(long ID)
          {
               return db.Users.Where(x => x.ID == ID).SingleOrDefault();
          }
          // Them nguoi dung moi
          public bool AddUser(User us)
          {
               try
               {
                    db.Users.Add(us);
                    db.SaveChanges();
                    return true;
               }
               catch (Exception e)
               {
                    return false;
               }
          }
          // Kiem tra email trung lap
          public bool ExistedEmail(string email)
          {
               if (db.Users.Count(x => x.Email == email) > 0)
               {
                    return true;
               }
               return false;
          }
          public bool ValidEmail(string email)
          {
               using (WebClient webclient = new WebClient())
               {
                    string url = "http://verify-email.org";
                    NameValueCollection formdata = new NameValueCollection();
                    formdata["check"] = email;
                    byte[] responsebyte = webclient.UploadValues(url, "POST", formdata);
                    string reponse = Encoding.ASCII.GetString(responsebyte);
                    if (reponse.Contains("Result: Ok"))
                         return true;
                    return false;
               }
          }
          public bool ChangeStatus(long id)
          {
               var user = db.Users.Find(id);
               user.Status = !user.Status;
               db.SaveChanges();
               return (bool)user.Status;
          }
     }
}