using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class RssHeader
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
    }
}