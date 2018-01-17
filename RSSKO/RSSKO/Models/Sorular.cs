using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class Sorular
    {
        public int Id { get; set; }
        public string RssHeader { get; set; }
        public string Soru { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Cevap { get; set; }

        public virtual ICollection<Sonuclar> Sonuclar { get; set; }
    }
}