using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class Sonuclar
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SoruId { get; set; }
        public string Cevap1 { get; set; }
        public string Cevap2 { get; set; }
        public string Cevap3 { get; set; }
        public string Cevap4 { get; set; }
        public int DoSa { get; set; }
        public int YaSa { get; set; }

        [ForeignKey("SoruId")]
        public virtual Sorular Sorular { get; set; }

        [ForeignKey("UserId")]
        public virtual User Userlar { get; set; }
    }
}