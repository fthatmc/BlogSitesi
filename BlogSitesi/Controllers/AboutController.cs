using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository repo = new AboutRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            TblAbout t = repo.Find(x => x.AboutID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditAbout(TblAbout p)
        {
            TblAbout t = repo.Find(x => x.AboutID == p.AboutID);
            t.Header = p.Header;
            t.Title = p.Title;
            t.Description = p.Description;
            t.ImageUrl = p.ImageUrl;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}