

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
using BookMVC.Dao;
namespace BookMVC.Dao
{
     public class OrderDao
     {
          BookMVCDbContext db = null;
          public OrderDao()
          {
               db = new BookMVCDbContext();
          }
          public void CreateOrder(long UserID, List<CartItem> listSelected,long shipTypeID)
          {
               var user = new UserDao().GetUser(UserID);
               var orderdetail = new Order_DetailDao();
               var order = new Order()
               {
                    CreateDate = DateTime.Now,
                    CreatID = UserID,
                    ShipName = user.Name,
                    ShipMobile = user.Phone,
                    ShipAdress = user.Adress,
                    ShipEmail = user.Email,
                    ShipTypeID = shipTypeID
               };
               db.Orders.Add(order);
               db.SaveChanges();
          }
          public Order TakeOrder(long orderID)
          {
               return db.Orders.Where(x => x.ID == orderID).SingleOrDefault();
          }
          public bool checkOrderExsit(long orderID) => TakeOrder(orderID) != null ? true : false;
          public bool DeleteOrder(long orderID)
          {
               if (checkOrderExsit(orderID))
               {
                    var order = TakeOrder(orderID);
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    return true;
               }
               return false;
          }
     }
}