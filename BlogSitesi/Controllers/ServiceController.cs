using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        ServiceRepository repo = new ServiceRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        public ActionResult DeleteService(int id)
        {
            TblService t = repo.Find(x=>x.ServiceID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService t)
        {
            repo.Add(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditService(int id)
        {
            TblService t = repo.Find(x => x.ServiceID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditService(TblService p)
        {
            TblService t = repo.Find(x => x.ServiceID == p.ServiceID);
            t.Header = p.Header;
            t.Description = p.Description;
            t.ImageUrl = p.ImageUrl;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}