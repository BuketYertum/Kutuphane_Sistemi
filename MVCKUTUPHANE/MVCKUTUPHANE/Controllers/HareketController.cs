using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class HareketController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Hareket
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKETLER.Where(X => X.ISLEMDURUM == false).ToList(); //SADECE EMANET KİTAPLARIN LİSTESİ GELSİN..
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKETLER h)
        {
            db.TBL_HAREKETLER.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult OduncIade(TBL_HAREKETLER p)
        {
            var odunc = db.TBL_HAREKETLER.Find(p.ID);
            DateTime d1 = DateTime.Parse(odunc.IADETARIHI.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("OduncIade", odunc);
        }

        public ActionResult OduncGuncelle(TBL_HAREKETLER t)
        {
            var hrkt = db.TBL_HAREKETLER.Find(t.ID);
            hrkt.UYEGETIRTARIH = t.UYEGETIRTARIH;
            hrkt.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

    }
}