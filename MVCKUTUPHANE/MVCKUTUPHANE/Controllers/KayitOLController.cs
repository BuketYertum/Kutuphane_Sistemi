﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class KayitOLController : Controller
    {
        DboKutuphaneEntities db = new DboKutuphaneEntities();
        // GET: KayitOL

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Kayit(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}