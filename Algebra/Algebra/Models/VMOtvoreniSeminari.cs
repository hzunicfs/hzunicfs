using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Models
{
    public class VMOtvoreniSeminari
    {
        public Otvoreni_seminari Otvoreniseminari { get; set; }
        public IEnumerable<Otvoreni_seminari> IEOtvoreniseminari { get; set; }


        public IEnumerable<SelectListItem> SLAdresaodrzavanja { get; set; }
        public IEnumerable<Adresa_odrzavanja> IEAdresaodrzavanja { get; set; }
        public Adresa_odrzavanja Adresaodrzavanja { get; set; }

        public IEnumerable<SelectListItem> SLPredavaci { get; set; }
        public IEnumerable<Predavaci> IEPredavaci { get; set; }

        [Display(Name = "PREDAVAČ")]
        public Predavaci Predavaci { get; set; }

        public Seminari Seminari { get; set; }
        public IEnumerable<SelectListItem> SLSeminari { get; set; }
        public IEnumerable<Seminari> IESeminari { get; set; }

        public Upisi Upisi { get; set; }
        public IEnumerable<Upisi> IEUpisi { get; set; }
        [Display(Name = "BROJ UPISANIH")]
        public BrojUpisanih BrojUpisanih {get;set;}
        public IEnumerable<BrojUpisanih> IEBrojUpisanih { get; set; }
        public UpisanihBroj UpisanihBroj { get; set; }
        public IEnumerable<UpisanihBroj> IEUpisanihBroj { get; set; }
    }
}