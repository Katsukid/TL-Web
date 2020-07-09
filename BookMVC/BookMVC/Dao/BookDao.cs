using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookMVC.Entities;
using PagedList;
using PagedList.Mvc;
namespace BookMVC.Dao
{
     public class BookDao
     {
          BookMVCDbContext db;
          public BookDao()
          {
               db = new BookMVCDbContext();
          }
          // Lay toan bo sach
          public List<Book> ListAll()
          {
               return db.Books.ToList();
          }
          // Lay mot vai quyen sach
          public List<Book> ListSomeBook(int number)
          {
               return db.Books.Take(number).ToList();
          }
          // Lay danh sach
          // Sach moi ( < days ngay)
          public List<Book> ListNewBook(int days)
          {
               int hour = days * 24;
               TimeSpan ts = new TimeSpan(hour, 0, 0);
               return db.Books.Where(x => DateTime.Now - x.PublishDate <= ts).OrderByDescending(x => x.PublishDate).ToList();
          }
          public List<Book> ListNewBook(int days,int count)
          {
               int hour = days * 24;
               TimeSpan ts = new TimeSpan(hour, 0, 0);
               return db.Books.Where(x => DateTime.Now - x.PublishDate <= ts).OrderByDescending(x => x.PublishDate).Take(count).ToList();
          }
          // Sap phat hanh
          public List<Book> ListFutureBook()
          {
               return db.Books.Where(x => x.PublishDate > DateTime.Now).OrderByDescending(x => x.PublishDate).ToList();
          }
          public List<Book> ListFutureBook(int count)
          {
               return db.Books.Where(x => x.PublishDate > DateTime.Now).OrderByDescending(x => x.PublishDate).Take(count).ToList();
          }
          // Sach ban chay
          public List<Book> ListHotBook(int number)
          {
               return db.Books.OrderByDescending(x => x.Buys).Take(number).ToList();
          }
          // Theo tac gia
          public List<Book> ListByAuthor(string author)
          {
               return db.Books.Where(x => x.Author == author).ToList();
          }
          public List<Book> ListByAuthor(string author, int count)
          {
               return db.Books.Where(x => x.Author == author).Take(6).ToList();
          }
          // Theo danh muc
          public List<Book> ListByBookCategory(long? id)
          {
               return db.Books.Where(x => x.CategoryID == id).ToList();
          }
          public List<Book> ListByBookCategory(long? id, int count)
          {
               return db.Books.Where(x => x.CategoryID == id).Take(count).ToList();
          }
          public List<Book> ListByNXB(string nxb)
          {
               return db.Books.Where(x => x.NXB == nxb).ToList();
          }
          public List<Book> ListByNXB(string nxb,int count)
          {
               return db.Books.Where(x => x.NXB == nxb).Take(count).ToList();
          }
          // Lay sach
          // Theo ID
          public Book FindByID(long? id)
          {
               return db.Books.Where(x => x.ID == id).SingleOrDefault();
          }
          // Theo ten
          public Book FindByName(string name)
          {
               return db.Books.Where(x => x.Name == name).SingleOrDefault();
          }
          // Theo ma sach
          public Book FindByCode(string code)
          {
               return db.Books.Where(x => x.code == code).SingleOrDefault();
          }
          // Thao tac
          // Them sach
          public bool AddBook(Book b)
          {
               db.Books.Add(b);
               db.SaveChanges();
               return true;
          }
          // Cap nhat so luot xem
          public void UpdateViews(long? id)
          {
               try
               {
                    var book = db.Books.Find(id);
                    book.ViewCount++;
                    db.SaveChanges();
               }
               catch (Exception ex)
               {

               }
          }
          public bool IsNew(Book b)
          {
               int days = 30;
               int hour = days * 24;
               TimeSpan ts = new TimeSpan(hour, 0, 0);
               return (DateTime.Now - b.PublishDate <= ts);
          }
          public bool IsSale(Book b)
          {
               return (b.PromotionPrice != b.Price);
          }
          //Lấy ra hình thức sách
          public List<string> Form()
          {
               return new List<string>() { "Bìa mềm", "Bìa cứng" };
          }
          //Kiểm tra số lượng tồn kho
          public decimal getInventory(long id)
          {
               var inventory = FindByID(id).Inventory;
               if (inventory == null || inventory <= 0) return 0;
               return (decimal)inventory;
          }

          //Phân trang trong admin
          public IEnumerable<Book> listBookPage(string searchString, int page, int pagesize)
          {
               IQueryable<Book> model = db.Books;
               if (!string.IsNullOrEmpty(searchString))
               {
                    model = model.Where(x => x.Name.Contains(searchString));
               }
               return model.OrderByDescending(x => x.PublishDate < DateTime.Now).ToPagedList(page, pagesize);
          }
     }
}