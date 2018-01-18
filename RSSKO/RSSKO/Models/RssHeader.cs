using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class RssHeader
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PubDate { get; set; }

        public virtual ICollection<Sorular> Sorular { get; set; }
    }
}