using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class KitapController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {

            var kitaplar = from i in db.TBL_KITAP select i;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(k => k.AD.Contains(p));
            }
            //var degerler = db.TBL_KITAP.ToList();
            return View(kitaplar.ToList());
        }



        [HttpGet]
        public ActionResult YeniKitap()
        {
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from j in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = j.AD,
                                               Value = j.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }



        [HttpPost]
        public ActionResult YeniKitap(TBL_KITAP p)
        {
            var ktg = db.TBL_KATEGORILER.Where(k => k.ID == p.TBL_KATEGORILER.ID).FirstOrDefault();
            var yzr = db.TBL_YAZAR.Where(t => t.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            p.TBL_KATEGORILER = ktg;
            p.TBL_YAZAR = yzr;
            p.DURUM = true;
            db.TBL_KITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Sil(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            db.TBL_KITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(int id)
        {
            var ktp=db.TBL_KITAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBL_KATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


            List<SelectListItem> deger2 = (from j in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = j.AD,
                                               Value = j.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("Getir", ktp);
        }


        public ActionResult Guncelle(TBL_KITAP p)
        {
            var deger = db.TBL_KITAP.Find(p.ID);
            deger.AD = p.AD;
            deger.BASIMYILI = p.BASIMYILI;
            deger.SAYFA = p.SAYFA;
            deger.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBL_KATEGORILER.Where(k => k.ID == p.TBL_KATEGORILER.ID).FirstOrDefault();
            var yzr = db.TBL_YAZAR.Where(t => t.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            deger.KATEGORI = ktg.ID;
            deger.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}