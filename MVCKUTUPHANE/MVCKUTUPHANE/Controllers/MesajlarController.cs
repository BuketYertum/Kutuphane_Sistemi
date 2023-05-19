using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;


namespace MVCKUTUPHANE.Controllers
{
    public class MesajlarController : Controller
    {
        DboKutuphaneEntities db = new DboKutuphaneEntities();

        // GET: Mesajlar
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var degerler = db.TBL_MESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList();
            //var degerler = db.TBL_MESAJLAR.ToList();
            return View(degerler);
        }


        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var degerler = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            //var degerler = db.TBL_MESAJLAR.ToList();
            return View(degerler);
        }



        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniMesaj(TBL_MESAJLAR p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN = uyemail.ToString();
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_MESAJLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
    }
}