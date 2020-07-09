using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCDemo.Entities;

namespace MVCDemo.Dao
{
    public class OfficeDao
    {
        MyClassDbContext db;
        public OfficeDao()
        {
            db = new MyClassDbContext();
        }
        public int InsertOffice(string Name)
        {
            Office office = new Office();
            office.Name = Name;
            db.Office.Add(office);
            db.SaveChanges();
            return office.Code;
        }
        public IQueryable<Office> Offices
        {
            get { return db.Office; }
        }
        public IQueryable<Office> ListOffice()
        {
            var res = (from s in db.Office
                       where s.Code>2 || s.Name.Length>2
                       orderby s.Name descending
                       select s);
            return res;
        }
        public void UpdateOffice(Office officeTmp)
        {
            Office office = db.Office.Find(officeTmp.Code);
            if(office!=null)
            {
                office.Name = officeTmp.Name;
                db.SaveChanges();
            }

        }
        public void DeleteOffice(Office officeTmp)
        {
            Office office = db.Office.Find(officeTmp.Code);
            if (office != null)
            {
                db.Office.Remove(office);
                db.SaveChanges();
            }

        }
        public Office FindOfficeByICode(int Code)
        {
            return db.Office.Find(Code);
        }
  
   

    }
}