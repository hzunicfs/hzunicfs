using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    
    public class Adresa_odrzavanja
    {
        [Required(ErrorMessage = "Adresa održavanja ID je obavezno")]
        [Column(Order = 0)]
        [Key]
        [Display(Name = "Adresa održavanja ID")]
        public int AO_ID { get; set; }

        [Display(Name = "ULICA")]
        [Required(ErrorMessage = "Ulica je obavezna")]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Ulica { get; set; }

       
        [Required(ErrorMessage = "Kućni broj je obavezan")]
        [Column(Order = 2)]
        [Display(Name = "KUĆNI BROJ")]
        public string Kucni_broj { get; set; }

        [Display(Name = "GRAD")]
        [Required(ErrorMessage = "Grad je obavezan")]
        [Column(Order = 3)]
        public string Grad { get; set; }

        [Column(Order = 4)]
        [Display(Name = "POŠTANSKI BROJ")]
        public string Postanski_broj { get; set; }

        [Required(ErrorMessage = "Država je obavezna")]
        [Column(Order = 5)]
        [Display(Name = "DRŽAVA")]
        public string Drzava { get; set; }
    }
}