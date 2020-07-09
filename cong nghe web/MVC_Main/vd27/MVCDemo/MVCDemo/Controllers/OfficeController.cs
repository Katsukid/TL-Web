using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Dao;
using MVCDemo.Entities;

namespace MVCDemo.Controllers
{
    public class OfficeController : Controller
    {
        //
        // GET: /Office/
        public ActionResult Index()
        {
            OfficeDao dao = new OfficeDao();
           // IQueryable<Office> Offices = dao.Offices;
            IQueryable<Office> Offices= dao.ListOffice();
            return View("List", Offices);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            OfficeDao dao = new OfficeDao();
            Office office = dao.FindOfficeByICode(id);
            dao.DeleteOffice(office);
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            OfficeDao dao = new OfficeDao();

            Office office = dao.FindOfficeByICode(id);
            return View(office);
        }
        public ActionResult EditAction(Office office)
        {
            OfficeDao dao = new OfficeDao();
            dao.UpdateOffice(office);
            return RedirectToAction("Index");
        }

        public ActionResult AddAction(Office office)
        {
            OfficeDao dao = new OfficeDao();
            dao.InsertOffice(office.Name);
            return RedirectToAction("Index");
        }

        

	}
}