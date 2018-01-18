using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class Sorular
    {
        public int Id { get; set; }
        public int RssHeaderId { get; set; }
        public string Soru { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Cevap { get; set; }

        [ForeignKey("RssHeaderId")]
        public virtual RssHeader RssHeader { get; set; }

        public virtual ICollection<Sonuclar> Sonuclar { get; set; }
    }
}