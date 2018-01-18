using RSSKO.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace RSSKO.Controllers
{
    public class HomeController : Controller
    {
        RssContext db = new RssContext();

        public ActionResult Index()
        {

            WebClient wclient = new WebClient();
            string RSSData = wclient.DownloadString("https://www.wired.com/feed/rss");

            XDocument xml = XDocument.Parse(RSSData);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RssHeader
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((DateTime)x.Element("pubDate"))
                               }).Take(5);
            ViewBag.RssFeed = RSSFeedData;
            return View();
        }

        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var kontrol = db.Userlar.Where(m => m.Email == user.Email).FirstOrDefault();
            if (kontrol != null )
            {
                ViewBag.MailKontrol = "Bu mail Adresi mevcuttur!";
                return View();
            }
            else if (ModelState.IsValid)
            {
                user.IsAdmin = false;
                db.Userlar.Add(user);
                db.SaveChanges();
                ViewBag.Mesaj = "Kayıt Yapıldı";
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var kontrol = db.Userlar.Where(m => m.Email == user.Email && m.Sifre == user.Sifre).FirstOrDefault();

            if (kontrol != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mesaj = "Lütfen bilgileri kontrol edip tekrar deneyiniz";
                return View();
            }
        }

        [HttpPost]
        public ActionResult RssKaydet(RssHeader rssHeader)
        {
            db.RssHeaderlar.Add(rssHeader);
            db.SaveChanges();
            return Json(rssHeader.ID);
        }
    }
}