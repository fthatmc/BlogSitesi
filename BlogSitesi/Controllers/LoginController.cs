using BlogSitesi.Model.Entity;
using BlogSitesi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSitesi.Controllers
{
    [AllowAnonymous] //[Authorize] için global dekini ekledikten sonra burası
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {

            DbMyPortFolioEntities db = new DbMyPortFolioEntities();
            var information = db.TblAdmin.FirstOrDefault
                (x=>x.UserName==p.UserName && x.Password==p.Password);

            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.UserName, false);
                Session["UserName"] = information.UserName.ToString();
                return RedirectToAction("Index", "Future");
            }
            else { return RedirectToAction("Index", "Login"); }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        //üst tarafı tamamladıktan sonra
        //1.    view de input name="username" düzenle
        //2.    sonra web config de 

        //<authentication mode = "Forms" >
        //< forms loginUrl="/Login/Index/">
        //</forms>
        // </authentication>

        //3.    GlobalAsax'da : GlobalFilters.Filters.Add(new AuthorizeAttribute()); bunu yaz
        //4.    en üste [AllowAnonymous] bunu yaz
    }
}