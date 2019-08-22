using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Upisani

    {
        [Key]
        public string Id_Upisani { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, ErrorMessage = "Ime ne smije biti veci od 50 znakova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage = "Prezime ne smije biti veci od 50 znakova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "OIB je obavezan")]
        [StringLength(11,MinimumLength = 11,ErrorMessage ="OIB se sastoji od 11 znamenki")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "OIB se sastoji od 11 znamenki")]
        public string OIB { get; set; }

        [Required(ErrorMessage = "Broj osobne je obavezan")]
        [Display(Name ="Broj osobne")]
        public string Broj_osobne { get; set; }

        public string Id_Adresa { get; set; }
        public Adrese_upisanih Adrese_upisanih { get; set; }

        public string Id_OS { get; set; }
        public Otvoreni_seminari Otvoreni_seminari { get; set; }
        public string Email { get; set; }

        public long Telefon {get; set;}
    }
}