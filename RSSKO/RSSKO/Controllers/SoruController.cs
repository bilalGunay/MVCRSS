using Microsoft.Ajax.Utilities;
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
            db.Sorular.Add(sorular);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult SinavKonulari()
        {
            var sorular = db.Sorular.DistinctBy(s => s.RssHeaderId);
            return View(sorular);
        }

        public ActionResult Test(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var test = db.Sorular.Where(x => x.RssHeaderId == id).ToList();

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }


        public ActionResult Sil(int? id)
        {
            if (id != null)
            {
                var soruKontrol = db.Sorular.Where(s => s.RssHeaderId == id).ToList();
                for (int i = 0; i < soruKontrol.Count; i++)
                {
                    Sorular sorular = db.Sorular.Where(s => s.RssHeaderId == id).FirstOrDefault();
                    db.Sorular.Remove(sorular);
                    db.SaveChanges();
                }
            }
            return Json("");
        }
    }
}