using MyWebSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Models.Dto;

namespace MyWebSite.Models.Dao
{
    public class Data
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }

    }
    public class UserDao
    {
        
        TavShopModel tavShopModel;

        public UserDao()
        {
            tavShopModel = new TavShopModel();
        }
        public bool Login(string UserName, string Pwd)
        {
            var rs = tavShopModel.Users
                .Count(x=>x.UserName== UserName && x.Password== Pwd);
            if (rs > 0)
                return true;
            else
                return false;
        }
        public IQueryable<User> ListUser()
        {
            var rs = (from us in tavShopModel.Users select us);
            return rs;
        }
        public void Update(string UserName)
        {
            User us = tavShopModel.Users.Find(UserName);
        }
        public IQueryable<UserDTO> ListUserJoin()
        {
            var rs = from us in tavShopModel.Users
                     join gr in tavShopModel.UserGroups
                     on us.UserGroupID equals gr.ID
                     select new UserDTO
                     {
                         UserName=us.UserName,
                         UserGroupName=gr.Name
                     };
            return rs;
        }





        public IQueryable<Data> ListUserFields()
        {
            var rs = (from us in tavShopModel.Users
                      select new
                      Data{
                          Name=us.UserName,
                          Password=us.Password
                      });
            return rs;
        }
        public IQueryable<Data> ListUserFieldsJoin()
        {
            var rs = (from p in tavShopModel.Users
                      join c in tavShopModel.UserGroups
                      on p.UserGroupID  equals c.ID
                      select new
                      Data
                      {
                          Name = p.UserName,
                          Password = p.Password,
                          GroupName=c.Name
                      });
            return rs;
        }

    }
}