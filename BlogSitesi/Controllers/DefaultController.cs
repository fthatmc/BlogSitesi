using BlogSitesi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous] //sayfaya şifresiz erişim izni için önemli
    public class DefaultController : Controller
    {
        // GET: Default

        DbMyPortFolioEntities db = new DbMyPortFolioEntities();
        public ActionResult Index()
        {
            var value = db.TblFuture.ToList();
            return View(value);
        }

        public PartialViewResult About()
        {
            var value = db.TblAbout.ToList();
            return PartialView(value);
        }

        public PartialViewResult Service()
        {
            var value = db.TblService.ToList();
            return PartialView(value);
        }

        public PartialViewResult Project()
        {
            var value = db.TblProject.ToList();
            return PartialView(value);
        }

        public PartialViewResult Testimonial()
        {
            var value = db.TblTestimonial.Where(x=>x.Status==true).ToList();
            return PartialView(value);
        }

        public PartialViewResult SocialMedia()
        {
            var value = db.TblSocialMedia.ToList();
            return PartialView(value);
        }


        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}