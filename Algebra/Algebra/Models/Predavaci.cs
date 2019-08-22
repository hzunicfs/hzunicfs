using Algebra.Models.Validacije;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
  
    public class Predavaci
    {   [Key]
        [Required(ErrorMessage = "Predavci ID je obavezno")]
        [Column(Order = 0)]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Predavaci ID može sadržavati znamenke 0-9")]
        [Display(Name = "PREDAVAČ ID")]
        public int Predavaci_ID { get; set; }

        [Display(Name = "IME")]
        [Required(ErrorMessage = "Ime je obavezno")]
        [StringLength(50, ErrorMessage = "Ime ne smije biti veci od 50 znakova")]
        [Column(Order = 1)]
        public string Ime { get; set; }

        [Display(Name = "PREZIME")]
        [Required(ErrorMessage = "Prezime je obavezno")]
        [StringLength(50, ErrorMessage = "Prezime ne smije biti veci od 50 znakova")]
        [Column(Order = 2)]
        public string Prezime { get; set; }

        
        [Index("IX_PredavaciIndex1", IsUnique = true)]
        [Required(ErrorMessage = "OIB je obavezan")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "OIB se sastoji od 11 znamenki")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "OIB se sastoji od 11 znamenki 0-9")]
        [Column(Order = 3)]
        public string OIB { get; set; }

        [StringLength(20)]
        [Index("IX_PredavaciIndex2", IsUnique = true)]
        [Required(ErrorMessage = "Broj osobne je obavezan")]
        [Display(Name = "BROJ OSOBNE")]
        [Column(Order = 4)]
        public string Broj_osobne { get; set; }

      
        [Display(Name = "ADRESA STANOVANJA")]
        [Column(Order = 5)]
        public int AP_ID { get; set; }
        public Adresepredavaca Adrese_predavaca { get; set; }

        [StringLength(40, ErrorMessage = "Email može sadržavati do 40 znakova")]
        [Index("IX_PredavaciIndex3", IsUnique = true)]
        [Display(Name = "EMAIL")]
        [Required(ErrorMessage = "Email je obavezan")]
        [Column(Order = 6)]
        [EmailAddress(ErrorMessage="Neispravna email adresa")]
        public string Email { get; set; }


        [Display(Name = "TELEFON")]
        [Required(ErrorMessage = "Broj telefona je obavezan")]
        [Column(Order = 7)]
        public long Telefon { get; set; }


    }
}