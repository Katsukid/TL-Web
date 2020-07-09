using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookMVC.Entities;
using BookMVC.Dao;
namespace BookMVC.Controllers
{
         public class BookController : Controller
         {
          // GET: Book
          public ActionResult Index()
          {
               return View();
          }

          public ActionResult Card(Book b)
          {
               ViewBag.isNew = new BookDao().IsNew(b);
               return PartialView(b);
          }

          public ActionResult Detail(long? id)
          {
               //Lấy sách đó ra
               var book = new BookDao().FindByID(id); // Dùng để lấy danh sách cung loại, cùng tác giả
               // Lay danh muc
               var bookcategory = new BookCatgoryDao().FindByID(book.CategoryID.Value);
               // Cập nhật số lượt xem
               new BookDao().UpdateViews(book.ID);
               bool isNew = new BookDao().IsNew(book);
               bool isSale = new BookDao().IsSale(book);
               // Truyền sang View
               ViewBag.Book = book;
               ViewBag.SameAuthor = new BookDao().ListByAuthor(book.Author,4);
               ViewBag.SameCategory = new BookDao().ListByBookCategory(book.CategoryID.Value,4);
               ViewBag.Category = new CategoryDao().FindByID(bookcategory.ParentID.Value);
               ViewBag.BookCategory = bookcategory;
               ViewBag.isNew = isNew;
               ViewBag.iSale = isSale;
               return View();
          }

          public ActionResult ListAll()
          {
               return PartialView();
          }
          public ActionResult NewBook()
          {
               return View();
          }
    }
}