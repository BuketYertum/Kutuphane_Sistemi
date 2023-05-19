using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class YazarController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZAR.ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniYazar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniYazar(TBL_YAZAR y)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniYazar");
            }
            db.TBL_YAZAR.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var yzr=db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(yzr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(int id)
        {
            var yazar = db.TBL_YAZAR.Find(id);
            return View("Getir", yazar);
        }

        public ActionResult Guncelle(TBL_YAZAR y)
        {
            var deger=db.TBL_YAZAR.Find(y.ID);
            deger.AD = y.AD;
            deger.SOYAD = y.SOYAD;
            deger.DETAY = y.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}