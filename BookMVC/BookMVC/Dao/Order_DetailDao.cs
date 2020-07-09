using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
namespace BookMVC.Dao
{
     public class Order_DetailDao
     {
          BookMVCDbContext db;
          public Order_DetailDao()
          {
               db = new BookMVCDbContext();
          }
          public void AddOrderItem(long orderID, long ItemID, int quantity, decimal price)
          {
               if (new OrderDao().checkOrderExsit(orderID))
               {
                    var item = new Order_Detail()
                    {
                         OrderID = orderID,
                         BookID = ItemID,
                         Quantity = quantity,
                         Price = price
                    };
                    db.Order_Detail.Add(item);
                    db.SaveChanges();
               }
          }
          public Order_Detail TakeOderItem(long orderID,long ItemID)
          {
              return db.Order_Detail.Where(x => x.OrderID == orderID && x.BookID == ItemID).SingleOrDefault();
          }
          public void DeleteOrderItem(long orderID, long ItemID)
          {
               var item = TakeOderItem(orderID, ItemID);
               db.Order_Detail.Remove(item);
               db.SaveChanges();
          }
     }
}