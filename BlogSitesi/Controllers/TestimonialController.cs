using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial

        TestimonialRepository repo = new TestimonialRepository();
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        public ActionResult DeleteTestimonil(int id)
        {
            TblTestimonial t = repo.Find(x=>x.TestimonialID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTestimonil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonil(TblTestimonial t)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTestimonil");
            }
            t.Status = true;
            repo.Add(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTestimonil(int id)
        {
            TblTestimonial t = repo.Find(x => x.TestimonialID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EditTestimonil(TblTestimonial p)
        {
            
            TblTestimonial t = repo.Find(x => x.TestimonialID == p.TestimonialID);
            t.NameSurname = p.NameSurname;
            t.ImageUrl= p.ImageUrl;
            t.Description = p.Description;
            t.Status = true;
            if (!ModelState.IsValid)
            {
                return View("EditTestimonil");
            }
            repo.Update(t);
            return RedirectToAction("Index");
        }

        public ActionResult ChangesStatusToTrue(int id)
        {
            repo.TestimonialStatusToTrue(id);
            return RedirectToAction("Index");
        }
        public ActionResult ChangesStatusToFalse(int id)
        {
            repo.TestimonialStatusToFalse(id);
            return RedirectToAction("Index");
        }
    }
}