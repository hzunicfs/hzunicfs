using Algebra.Models.Validacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Algebra.Models
{
    [Upisiii(ErrorMessage = "Osoba je već upisana na ovaj tečaj")]
    [EmailUpisani(ErrorMessage = "Email već postoji.")]
    [OsobnaUpisani(ErrorMessage = "Osoba sa tim brojem osobne iskaznice već postoji.Klikni za detalje.")]
    [OIBUpisani(ErrorMessage = "Osoba sa tim OIB-om već postoji.Klikni za detalje.")]
    public class VMUpisani
    {
        public IEnumerable<Upisani> IEUpisani { get; set; }

       
        public Upisani Upisani{get; set;}
        public ICollection<Adrese_upisanih> IEAdresaupisanih { get; set; }
        public Adrese_upisanih Adreseupisanih { get; set; }
        public IEnumerable<Otvoreni_seminari> IEOtvoreniseminari { get; set; }
        public Otvoreni_seminari Otvoreniseminari { get; set; }
        public Upisi Upisi { get; set; }
        public IEnumerable<Upisi> IEUpisi { get; set; }

        public IEnumerable<BrojUpisanih> IEBrojUpisanih { get; set; }
        public BrojUpisanih BrojUpisanih { get; set; }

        public IEnumerable<UpisanihBroj> IEUpisanihBroj { get; set; }
        public UpisanihBroj UpisanihBroj { get; set; }


    }
}