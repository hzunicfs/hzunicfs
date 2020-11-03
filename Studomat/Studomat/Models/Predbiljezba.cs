using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Predbiljezba
    {
        [Column(Order = 0)]
        [Key]
        [Display(Name = "Predbilježba ID")]
        public int Predbiljezba_ID { get; set; }

        [Display(Name = "IME")]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, ErrorMessage = "Ime ne smije biti veci od 50 znakova")]
        public string Ime { get; set; }

        [Display(Name = "PREZIME")]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage = "Prezime ne smije biti veci od 50 znakova")]
        public string Prezime { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Mjesto stanovanja je obavezno")]
        [Display(Name = "MJESTO STANOVANJA")]
        public string Mjesto_stanovanja { get; set; }

        [Display(Name = "TELEFON")]
        [Column(Order = 4)]
        public int Telefon { get; set; }

        [Display(Name = "EMAIL")]
        [Column(Order = 5)]
        [Required(ErrorMessage = "Email je obavezan")]
        [EmailAddress(ErrorMessage ="Neispravna email adresa")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum predbilježbe")]
        [Column(Order = 6)]
        public DateTime Datum_predbiljezbe { get; set; }

        [Display(Name = "OS ID")]
        [Column(Order = 7)]
        public int OS_ID { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "Opis ne smije biti veci od 500 znakova")]
        [Display(Name = "NAPOMENA")]
        [Column(Order = 8)]
        public string Napomena { get; set; }

    }
}