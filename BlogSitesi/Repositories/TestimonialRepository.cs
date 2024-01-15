using BlogSitesi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSitesi.Repositories
{
    public class TestimonialRepository : GenericRepository<TblTestimonial>
    {
        DbMyPortFolioEntities db = new DbMyPortFolioEntities();
        public void TestimonialStatusToTrue(int id)
        {

            TblTestimonial t = db.TblTestimonial.Find(id);
            t.Status = true;
            db.SaveChanges();
        }
        public void TestimonialStatusToFalse(int id)
        {

            TblTestimonial t = db.TblTestimonial.Find(id);
            t.Status = false;
            db.SaveChanges();
        }
    }
}