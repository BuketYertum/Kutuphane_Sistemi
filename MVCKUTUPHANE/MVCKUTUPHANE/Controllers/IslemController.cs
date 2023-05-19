using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class IslemController : Controller
    {

        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKETLER.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}