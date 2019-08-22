using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Seminari
    {
        [Key]
        [StringLength(5, ErrorMessage = "IdSeminar ne smije biti veći0 od 5 znakova")]
        public string IdSeminar { get; set; }

        [Required(ErrorMessage ="Naziv je obavezan")]
        [StringLength(50, ErrorMessage = "Naziv ne smije biti veci od 50 znakova")]
        public string Naziv { get; set; }

        [Required(ErrorMessage ="Opis je obavezan")]
        [StringLength(500,ErrorMessage= "Opis ne smije biti veci od 500 znakova")]
        public string Opis { get; set; }

        

    }
}