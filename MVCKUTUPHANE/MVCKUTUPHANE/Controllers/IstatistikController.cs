using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class IstatistikController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBL_KITAP.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.dgr4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.TBL_KITAP.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBL_UYELER.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.TBL_KATEGORILER.Count();
            ViewBag.dgr5 = deger5;
            var deger6 = db.TBL_ILETISIM.Count();
            ViewBag.dgr6 = deger6;
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8 = deger8;
            var deger9 = db.TBL_KITAP.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.dgr9 = deger9;
            var deger10 = db.TBL_HAREKETLER.GroupBy(x => x.UYE).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.dgr10 = deger10;
            var deger11 = db.TBL_HAREKETLER.GroupBy(x => x.PERSONEL).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.dgr11 = deger11;
            var deger12 = db.TBL_HAREKETLER.GroupBy(x => x.ALINANKITAP).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
            ViewBag.dgr12 = deger12;
            var deger13 = db.TBL_HAREKETLER.Where(x => x.ALISTARIHI == DateTime.Today).Count();
            ViewBag.dgr13 = deger13;

            return View();
        }
    }
}