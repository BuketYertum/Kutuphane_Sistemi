using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
using System.Web.Security;


namespace MVCKUTUPHANE.Controllers
{
    public class LoginController : Controller
    {
        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["MAIL"] = bilgiler.MAIL.ToString();
                TempData["ID"] = bilgiler.ID.ToString();
                TempData["AD"] = bilgiler.AD.ToString();
                TempData["ID"] = bilgiler.ID.ToString();
                TempData["SOYAD"] = bilgiler.SOYAD.ToString();
                TempData["KULLANICIADI"] = bilgiler.KULLANICIADI.ToString();
                TempData["SIFRE"] = bilgiler.SIFRE.ToString();
                TempData["OKUL"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "KullaniciPaneli");
            }
            else
            {
                return View();
            }
           
        }
    }
}