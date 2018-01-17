using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSSKO.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı ve soyadınızı girin")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!")]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan!")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public virtual ICollection<Sonuclar> Sonuclar { get; set; }
    }
}