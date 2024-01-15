using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class FutureController : Controller
    {
        // GET: Future

        FutureRepository repo = new FutureRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult EditFuture(int id)
        {
            TblFuture t = repo.Find(x=>x.FutureID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditFuture(TblFuture p)
        {
            TblFuture t = repo.Find(x => x.FutureID == p.FutureID);
            t.Header = p.Header;
            t.NameSurname = p.NameSurname;
            t.Title = p.Title;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }

    
}