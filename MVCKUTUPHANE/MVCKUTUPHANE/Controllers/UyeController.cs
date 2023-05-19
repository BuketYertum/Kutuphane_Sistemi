using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class UyeController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();

        // GET: Uye
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUye()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUye(TBL_UYELER u)
        {
            db.TBL_UYELER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(TBL_UYELER u)
        {
            var uye = db.TBL_UYELER.Find(u.ID);
            return View("Getir", uye);
        }


        public ActionResult Guncelle(TBL_UYELER p)
        {
            var uyeler = db.TBL_UYELER.Find(p.ID);
            uyeler.AD = p.AD;
            uyeler.SOYAD = p.SOYAD;
            uyeler.MAIL = p.MAIL;
            uyeler.KULLANICIADI = p.KULLANICIADI;
            uyeler.SIFRE = p.SIFRE;
            uyeler.FOTO = p.FOTO;
            uyeler.TELEFON = p.TELEFON;
            uyeler.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}