using BlogSitesi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class İstatislikController : Controller
    {
		// GET: İstatislik
		DbMyPortFolioEntities db = new DbMyPortFolioEntities();
		public ActionResult Index()
        {
            var deger1 = db.TblProject.Count().ToString();
            ViewBag.d1 = deger1;

			var deger2 = db.TblService.Count().ToString();
			ViewBag.d2 = deger2;

			var deger3 = db.TblTestimonial.Count().ToString();
			ViewBag.d3 = deger3;

			var deger4 = db.TblCategory.Count().ToString();
			ViewBag.d4 = deger4;


			var deger5 = (from x in db.TblProject orderby x.ProjectID descending select x.Title).FirstOrDefault().ToString();
			ViewBag.d5 = deger5;

			var deger6 = (from x in db.TblTestimonial orderby x.TestimonialID ascending select x.NameSurname).FirstOrDefault().ToString();
			ViewBag.d6 = deger6;

			var deger7 = db.TblContact.Count().ToString();
			ViewBag.d7 = deger7;

			DateTime bugun = DateTime.Today;
			var deger8 = db.TblContact.Count(x => x.SendDate == bugun).ToString();
			ViewBag.d8 = deger8;
			
			return View();

			
        }

		

	}
}