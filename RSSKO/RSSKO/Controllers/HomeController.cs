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
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                db.Userlar.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}