using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBConnectApp.Entities;

namespace DBConnectApp.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int id)
        {
            GioHangHoa gio = (GioHangHoa)Session["cart"];
            if (gio == null)
                gio = new GioHangHoa();
            //truy van tu csdl
            HangHoaBan hangHoa = new HangHoaBan(id, 1);
            gio.addHangHoa(hangHoa);
            Session["cart"] = gio;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult ViewCount()
        {
            GioHangHoa gio = (GioHangHoa)Session["cart"];
            if (gio == null)
                ViewBag.count = 0;
            else
                ViewBag.count = gio.getSL();
            return View();
        }
    }
}