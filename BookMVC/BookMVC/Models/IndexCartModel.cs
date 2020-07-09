using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
using BookMVC.Models;
namespace BookMVC.Models
{
     public class IndexCartModel
     {
          public decimal? totalPrice { get; set; }
          public decimal? totalQuantity { get; set; }
          public List<Book> listHotBook { get; set; }
          public List<CartItemDetail> cart { get; set; }
          public List<ShippingType> listShippingType { get; set; }
          public long? shippingType { get; set; }
          public string coupon { get; set; }
     }
}