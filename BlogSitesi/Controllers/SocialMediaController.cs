using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo = new SocialMediaRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            TblSocialMedia t = repo.Find(x=>x.SocialMediaID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia t)
        {
            repo.Add(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            TblSocialMedia t = repo.Find(x => x.SocialMediaID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditSocialMedia(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x => x.SocialMediaID == p.SocialMediaID);
            t.Title = p.Title;
            t.SocialMediaUrl = p.SocialMediaUrl;
            t.Icon = p.Icon;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}