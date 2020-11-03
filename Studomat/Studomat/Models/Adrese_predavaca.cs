using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    [Table("Adrese_predavaca")]
    public class Adresepredavaca
    {
        [Required(ErrorMessage = "Adresa predavača ID je obavezno")]
        [Column(Order = 0)]
        [Key]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Adrese predavača ID može sadržavati znamenke 0-9")]
        [Display(Name="Adresa predavača ID")]
        public int AP_ID { get; set; }

        [Required(ErrorMessage = "Ulica je obavezna")]
        [Column(Order = 1)]
        [StringLength(50)]
        [Display(Name = "ULICA")]
        public string Ulica { get; set; }

        [Required(ErrorMessage = "Kućni broj je obavezan")]
        [Column(Order = 2)]
        [Display(Name = "KUĆNI BROJ")]
        public string Kucni_broj { get; set; }

        [Required(ErrorMessage = "Grad je obavezan")]
        [Column(Order = 3)]
        [Display(Name = "GRAD")]
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