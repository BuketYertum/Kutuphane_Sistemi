using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class PersonelController : Controller
    {
        DboKutuphaneEntities db = new DboKutuphaneEntities();

        // GET: Personel
        public ActionResult Index()
        {
            var degerler = db.TBL_PERSONELLER.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(TBL_PERSONELLER p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniPersonel");
            }
            db.TBL_PERSONELLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var deger = db.TBL_PERSONELLER.Find(id);
            db.TBL_PERSONELLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Getir(TBL_PERSONELLER p)
        {
            var pers = db.TBL_PERSONELLER.Find(p.ID);
            return View("Getir", pers);
        }

        public ActionResult Guncelle(TBL_PERSONELLER p)
        {
            var personel = db.TBL_PERSONELLER.Find(p.ID);
            personel.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}