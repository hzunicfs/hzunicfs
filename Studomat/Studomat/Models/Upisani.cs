using Algebra.Models.Validacije;
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
        [Column(Order = 0)]
        [Key]
        [Display(Name = "UPISANI ID")]
        [Required(ErrorMessage = "Upisani ID je obavezno")]
        public int Upisani_ID { get; set; }

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

       
       
        [Index("IX_UpisaniIndex1", IsUnique = true)]
        [Column(Order = 3)]
        [Required(ErrorMessage = "OIB je obavezan")]
        [StringLength(11,MinimumLength = 11,ErrorMessage ="OIB se sastoji od 11 znamenki")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "OIB se sastoji od 11 znamenki")]
        public string OIB { get; set; }

        
        [StringLength(20)]
        [Index("IX_UpisaniIndex2", IsUnique = true)]
        [Display(Name = "BROJ OSOBNE")]
        [Column(Order = 4)]
        [Required(ErrorMessage = "Broj osobne je obavezan")]
        public string Broj_osobne { get; set; }
        

        [Column(Order = 5)]
        [Display(Name = "ADRESA UPISANIH")]
        public int AU_ID { get; set; }
        public Adrese_upisanih Adr_upi { get; set; }

        
        [StringLength(40, ErrorMessage = "Email može sadržavati do 40 znakova")]
        [Index("IX_UpisaniIndex3", IsUnique = true) ]
        [Display(Name = "EMAIL")]
        [Required(ErrorMessage = "Email je obavezan")]
        [Column(Order = 6)]
        [EmailAddress(ErrorMessage = "Neispravna email adresa")]
        public string Email { get; set; }

        [Display(Name = "TELEFON")]
        [Required(ErrorMessage = "Broj telefona je obavezan")]
        [Column(Order = 7)]
        public long Telefon {get; set;}
    }
}