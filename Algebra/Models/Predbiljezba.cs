using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Predbiljezba
    {
        [Key]
        [StringLength(5, ErrorMessage = "IdSeminar ne smije biti vece od 5 znakova")]
        public string IdPredbiljezbe { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Ime ne smije biti veci od 50 znakova")]
        public string Ime { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Prezime ne smije biti veci od 50 znakova")]
        public string Prezime { get; set; }

        public string MjestoStanovanja { get; set; }

        public int Telefon { get; set; }

        public string Email { get; set; }

        public DateTime Datum_predbiljezbe { get; set; }

        public int Broj_predbiljezbe { get; set; }



    }
}