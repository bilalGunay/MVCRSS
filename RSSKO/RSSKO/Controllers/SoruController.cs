using RSSKO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RSSKO.Controllers
{
    public class SoruController : Controller
    {
        RssContext db = new RssContext();
        // GET: Soru
        public ActionResult SoruKayit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RssHeader rss = db.RssHeaderlar.Find(ID);
            if (rss == null)
            {
                return HttpNotFound();
            }

            return View(rss);
        }

        [HttpPost]
        public ActionResult SoruKayit(Sorular sorular)
        {
            if (ModelState.IsValid)
            {
                db.Sorular.Add(sorular);
                return RedirectToAction("Index", "Home");
            }
            return View(sorular);
        }
    }
}