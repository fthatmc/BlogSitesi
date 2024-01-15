using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminRepository repo = new AdminRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }

        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin t)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAdmin");
            }
            
            repo.Add(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            TblAdmin t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditAdmin(TblAdmin p)
        {

            TblAdmin t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
            if (!ModelState.IsValid)
            {
                return View("EditAdmin");
            }
            repo.Update(t);
            return RedirectToAction("Index");
        }

    }
}