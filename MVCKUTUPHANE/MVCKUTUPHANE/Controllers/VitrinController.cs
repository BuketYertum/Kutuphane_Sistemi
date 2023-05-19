using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCKUTUPHANE.Models.Entity;
using MVCKUTUPHANE.Models.Class;

namespace MVCKUTUPHANE.Controllers
{
    public class VitrinController : Controller
    {
        DboKutuphaneEntities db = new DboKutuphaneEntities();

        // GET: Vitrin

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Value1 = db.TBL_KITAP.ToList();
            cs.Value2 = db.TBL_HAKKIMIZDA.ToList();

           // var degerler = db.TBL_KITAP.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(TBL_ILETISIM t)  //iki kez ındex kullandıgımız için birini get birini post olarak kullandım.
        {
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index"); 

        }
    }
}