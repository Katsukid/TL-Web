using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebSite.Models.Dao;
using MyWebSite.Models.Entities;
using MyWebSite.Models.Dto;

namespace MyWebSite.Controllers
{
    public class UserController : Controller
    {
        UserDao userDao;
        UserGroupDao userGroupDao;
        public ActionResult Index()
        {
            userDao = new  UserDao();
            IQueryable<UserDTO> lsUser = userDao.ListUserJoin();
            return View(lsUser);
        }

        public ActionResult Add()
        {
            userGroupDao = new UserGroupDao();
            IQueryable<UserGroup> ls = userGroupDao.ListUserGroups();
             return View(ls);
        }

    }
}