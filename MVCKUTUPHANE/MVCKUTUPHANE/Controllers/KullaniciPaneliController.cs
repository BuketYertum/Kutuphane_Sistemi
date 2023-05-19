using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class KullaniciPaneliController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();

        // GET: KullaniciPaneli
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["MAIL"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["MAIL"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.OKUL = p.OKUL;
            uye.FOTO = p.FOTO;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["MAIL"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKETLER.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

    }
}