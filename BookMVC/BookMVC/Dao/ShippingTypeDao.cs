using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
namespace BookMVC.Dao
{
     public class ShippingTypeDao
     {
          BookMVCDbContext db;
          public ShippingTypeDao()
          {
               db = new BookMVCDbContext();
          }
          public List<ShippingType> ListAll()
          {
               return db.ShippingTypes.ToList();
          }
          
     }
}