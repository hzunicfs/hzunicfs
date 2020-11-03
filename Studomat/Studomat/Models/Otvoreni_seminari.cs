using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    [Table("Otvoreni_seminari")]
    public class Otvoreni_seminari
    {
        [Column(Order = 0)]
        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Otvoreni seminari ID je obavezan")]
        public int OS_ID { get; set; }

        [Required(ErrorMessage = "Seminar je obavezan")]
        [Display(Name = "SEMINARI")]
        [Column(Order = 1)]
        public int Seminar_ID { get; set; }
        public Seminari Sem { get; set; }


        [Column(Order = 2)]
        [Required(ErrorMessage = "Broj polaznika je obavezan")]
        [Range(0, 999, ErrorMessage = "Maksimalan broj polaznika tecaja mora biti izmedu 0 i 999")]
        [Display(Name = "BROJ POLAZNIKA")]
        public int Broj_polaznika { get; set; }

        [Required(ErrorMessage = "Datum početka je obavezan")]
        [Column(Order = 3)]
        [Display(Name = "DATUM POČETKA")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Datum_pocetka { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Datum završetka je obavezan")]
        [Display(Name = "DATUM ZAVRŠETKA")]
        [Column(Order = 4)]
        public DateTime Datum_zavrsetka { get; set; }

        [Required(ErrorMessage = "Adresa održaanja je obavezna")]
        [Column(Order = 5)]
        [Display(Name = "ADRESA ODRŽAVANJA")]
        public int AO_ID { get; set; }
        public Adresa_odrzavanja Adre_odr { get; set; }


        [Required(ErrorMessage = "Predavač je obavezan")]
        [Column(Order = 6)]
        [Display(Name = "PREDAVAČ")]
        public int Predavaci_ID { get; set; }
        public Predavaci Pred { get; set; }

    }
}