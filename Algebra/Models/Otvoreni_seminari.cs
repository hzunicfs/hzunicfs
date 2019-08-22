using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class Otvoreni_seminari
    {
        [Key]
        public string Id_OS { get; set; }
 
        public string IdSeminar { get; set; }
        public Seminari Seminari { get; set; }

        [Required(ErrorMessage = "Broj polaznika je obavezan")]
        [Range(0, 999, ErrorMessage = "Ukupan broj polaznika tecaja mora biti izmedu 0 i 999")]
        public int Broj_polaznika { get; set; }

        public DateTime Datum_pocetka { get; set; }
        public DateTime Datum_zavrsetka { get; set; }

        public bool Popunjen { get; set; }

        public string Adresa_odrzavanja { get; set; }

        public string Predavac { get; set; }
    }
}