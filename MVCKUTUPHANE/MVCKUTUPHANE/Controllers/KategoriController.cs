using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;


namespace MVCKUTUPHANE.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        DboKutuphaneEntities db = new DboKutuphaneEntities();

        public ActionResult Index()
        {
            var values = db.TBL_KATEGORILER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var kategori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(int id)
        {
            var ktg = db.TBL_KATEGORILER.Find(id);
            return View("Getir", ktg);
        }


        public ActionResult Guncelle(TBL_KATEGORILER p)
        {
            var ktg = db.TBL_KATEGORILER.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}