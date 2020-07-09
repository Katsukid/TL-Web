using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
using BookMVC.Dao;
using BookMVC.Models;
using System.IO;
using System.Web.Routing;

namespace BookMVC.Controllers
{
     public class CartController : Controller
     {
          BookMVCDbContext db = new BookMVCDbContext();
          // GET: Cart
          public List<CartItemDetail> CreateCart(long? UserID)
          {
               var cart = from b in db.Books
                          join i in db.CartItems
                          on b.ID equals i.ItemID
                          where i.CustomerID == UserID
                          select new CartItemDetail() {
                               ItemID = b.ID,
                               Name = b.Name,
                               Price = b.Price,
                               Author = b.Author,
                               Image = b.Image,
                               Inventory = b.Inventory,
                               MetaTitle = b.MetaTitle,
                               Quantity = i.Quantity
                          };
               Session["Cart"] = cart.ToList();
               return cart.ToList();
          }
          // Lấy danh sách item trong Cart 
          public List<CartItemDetail> TakeCart()
          {
               return Session["Cart"] as List<CartItemDetail>;
          }
          // Tong so san pham
          public decimal? TotalQuantity()
          {
               var cart = TakeCart();
               if (cart == null || cart.Sum(x=>x.Quantity) == 0)
                    return 0;
               return cart.Sum(x => x.Quantity);
          }
          // Tong tien
          public decimal? TotalPrice()
          {
               var cart = TakeCart();
               if (cart == null || cart.Sum(x => x.Quantity) == 0)
                    return 0;
               decimal? sum = 0;
               foreach (var i in cart)
               {
                    sum += (i.Price * i.Quantity);
               }
               return sum;
          }
          // So luong sach trong gio hang hien thi tren TopNavBar va khoi tao Session["Cart"]
          public ActionResult CartPartial()
          {
               var UserID = Session["UserID"] as long?;
               if (Session["Cart"] == null && UserID != null)
                    CreateCart(UserID);
               ViewBag.TotalQuantity = TotalQuantity();
               ViewBag.TotalPrice = TotalPrice();
               return PartialView();
          }
          [HttpPost]
          public JsonResult Cart()
          {
               var UserID = Session["UserID"] as long?;
               if (Session["Cart"] == null && UserID != null)
                    CreateCart(UserID);
               return Json(new
               {
                    totalprice = TotalPrice(),
                    totalquantity = TotalQuantity()
               });
          }
          // Danh sach sach trong gio hang
          public ActionResult Index(long? listShippingType)
          {
               if (Session["UserID"] == null)
               {
                    TempData["message"] = "Please Login First";
                    return RedirectToAction("Index", "Home");
               }
               if (TotalQuantity() == 0)
               {
                    TempData["message"] = "There's no item in cart! Let shopping now!!";
                    return RedirectToAction("Index", "Home");
               }
               if (listShippingType == null)
               {
                    listShippingType = 1;
               }
               var group = new IndexCartModel
               {
                    cart = TakeCart(),
                    totalPrice = TotalPrice(),
                    totalQuantity = TotalQuantity(),
                    listHotBook = new BookDao().ListHotBook(4),
                    listShippingType = new ShippingTypeDao().ListAll(),
                    shippingType = listShippingType
               };
               return View(group);
          }
          public string RenderRazorViewToString(string viewName, object model)
          {
               ViewData.Model = model;
               using (var sw = new StringWriter())
               {
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                    return sw.GetStringBuilder().ToString();
               }
          }
          // Thêm Item vào Cart
          //[ValidateAntiForgeryToken]
          [HttpPost]
          public JsonResult AddCartItemInCart(long ItemID, long listShippingType)
          {
               var inventory = new BookDao().getInventory(ItemID);
               if (inventory == 0)
                    return Json(new
                    {
                         stringView = "Số lượng hàng trong kho không đủ!",
                         status = false
                    });
               var UserID = Session["UserID"] as long?;
               new CartItemDao().AddItem((long)UserID, ItemID,null);
               Session["Cart"] = CreateCart(UserID);
               var group = new IndexCartModel
               {
                    cart = CreateCart(UserID),
                    totalPrice = TotalPrice(),
                    totalQuantity = TotalQuantity(),
                    listHotBook = new BookDao().ListHotBook(4),
                    listShippingType = new ShippingTypeDao().ListAll(),
                    shippingType = listShippingType
               };
               return Json(new
               {
                    stringView = RenderRazorViewToString("Index", group),
                    status = true
               });
          }
          [HttpPost]
          public ActionResult AddCartItem(long ItemID, int? Quantity)
          {
               int check;
               var inventory = new BookDao().getInventory(ItemID);
               if (inventory == 0)
                    return Json(check = 0);
               var UserID = Session["UserID"] as long?;
               // Kiem tra dang nhap
               if (UserID == null)
               {
                    Session["message"] = "Please Login First";
                    return Json(check = 1);
               }
               new CartItemDao().AddItem((long)UserID, ItemID, Quantity);
               Session["Cart"] = CreateCart(UserID);
               return Json(check = 2);
          }
          // Xoa Item trong Cart
          [HttpPost]
          //[ValidateAntiForgeryToken]
          public JsonResult DeleteCartItem(long? ItemID,long listShippingType)
          {
               var UserID = Session["UserID"] as long?;
               var dao = new CartItemDao();
               var item = dao.TakeItem(UserID, (long)ItemID);
               if (item != null)
               {
                    dao.DeleteItem(item.ItemID);
                    var group = new IndexCartModel
                    {
                         cart = CreateCart(UserID),
                         totalPrice = TotalPrice(),
                         totalQuantity = TotalQuantity(),
                         listHotBook = new BookDao().ListHotBook(4),
                         listShippingType = new ShippingTypeDao().ListAll(),
                         shippingType = listShippingType
                    };
                    return Json(new
                    {
                         stringView = RenderRazorViewToString("Index", group),
                         status = true
                    });
               }
               
               return Json(new
               {
                    error = "Khong co san pham nay trong gio hang",
                    status = true
               });
          }
          //[HttpPost]
          //public ActionResult UpdateCartItem(long? ItemID,FormCollection form)
          //{
          //     CartItemDao cartdao = new CartItemDao();
          //     var UserID = Session["UserID"] as long?;
          //     var namebox = "Quantity+" + ItemID;
          //     var Quantity = Int32.Parse(form[namebox].ToString());
          //     if (cartdao.TakeItem(UserID, (long)ItemID) != null)
          //     {
          //          cartdao.UpdateItem(UserID, ItemID, Quantity);
          //          CreateCart(UserID);
          //     }
          //     else
          //          return RedirectToAction("Index");
          //     return RedirectToAction("Index");
          //}
          
          [HttpPost]
          [ValidateAntiForgeryToken]
          public JsonResult UpdateCartAll(FormCollection form,long listShippingType)
          {
               var cartdao = new CartItemDao();
               var UserID = Session["UserID"] as long?;
               var cart = TakeCart();
               foreach( var i in cart)
               {
                    var namebox = "Quantity+" + i.ItemID;
                    var Quantity = int.Parse(form[namebox].ToString());
                    if (cartdao.TakeItem(UserID, i.ItemID) != null)
                    {
                         cartdao.UpdateItem(UserID, i.ItemID, Quantity);
                    }
               }
               var group = new IndexCartModel
               {
                    cart = CreateCart(UserID),
                    totalPrice = TotalPrice(),
                    totalQuantity = TotalQuantity(),
                    listHotBook = new BookDao().ListHotBook(4),
                    listShippingType = new ShippingTypeDao().ListAll(),
                    shippingType = listShippingType
               };
               return Json(new {
                    stringView = RenderRazorViewToString("Index",group),
                    status = true
               });
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public JsonResult Coupon(string Serial)
          {
               var coupon = new CouponDao().TakeCoupon(Serial);
               if (coupon != null)
               {
                    if (coupon.StartDate < DateTime.Now && DateTime.Now < coupon.EndDate)
                         return Json(new
                         {
                              status = true,
                              discount = ((decimal)coupon.Discount).ToString("N0")
                         });
               }
               return Json(new
               {
                    status = false,
                    discount = 0
               });
              
          }
     }
}