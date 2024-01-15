using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        ProjectRepository repo = new ProjectRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        public ActionResult DeleteProject(int id)
        {
            TblProject t = repo.Find(x => x.ProjectID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject t)
        {
            repo.Add(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            TblProject t = repo.Find(x => x.ProjectID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditProject(TblProject p)
        {
            TblProject t = repo.Find(x => x.ProjectID == p.ProjectID);
            t.Title = p.Title;
            t.Description = p.Description;
            t.ImageUrl = p.ImageUrl;
            t.ProjectUrl = p.ProjectUrl;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}