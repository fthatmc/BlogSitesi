using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSitesi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo = new ContactRepository();
        public ActionResult Index()
        {
            var value = repo.List().Where(x=>x.IsRead==true).ToList();
            return View(value);
        }
        public ActionResult DeleteContact(int id)
        {
            var contact = repo.Find(x=>x.ContactID == id);
            contact.IsRead = false;
            repo.Update(contact);
            return RedirectToAction("Index");
        }

        
    }
}