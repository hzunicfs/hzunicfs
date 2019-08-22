using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Seminari
    {
        [Column(Order = 0)]
        [Key]
        [Display(Name = "SEMIANR ID")]
        [Required(ErrorMessage = "Seminar ID je obavezno")]
        public int Seminar_ID { get; set; }
        [Display(Name = "NAZIV")]
        [Column(Order = 1)]
        [Required(ErrorMessage ="Naziv je obavezan")]
        [StringLength(50, ErrorMessage = "Naziv ne smije biti veci od 50 znakova")]
        public string Naziv { get; set; }

        [Display(Name = "OPIS")]
        [DataType(DataType.MultilineText)]
        [Column(Order = 2)]
        [Required(ErrorMessage ="Opis je obavezan")]
        [StringLength(500,ErrorMessage= "Opis ne smije biti veci od 500 znakova")]
        public string Opis { get; set; }

        

    }
}