using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Models.Entities;

namespace MyWebSite.Models.Dao
{
    public class UserGroupDao
    {
        TavShopModel tavShopModel;
        public UserGroupDao()
        {
            tavShopModel = new TavShopModel();
        }
        public IQueryable<UserGroup> ListUserGroups()
        {
            var rs = (from us in tavShopModel.UserGroups select us);
            return rs;
        }
    }
}