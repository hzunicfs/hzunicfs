using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Algebra.Models.Pretrazivanje.VMOtvoreniSeminari
{
    public class VMOtvoreniSeminari_Pre
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

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDatumP { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDatumP { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDatumZ { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDatumZ { get; set; }

        public int? StartBrojP { get; set; }
        public int? EndBrojP { get; set; }

        public int? StartBrojUpisanih { get; set; }
        public int? EndBrojUpisanih { get; set; }
        public IEnumerable<BrojUpisanih> IEBrojUpisanih { get; set; }
        [Display(Name = "BROJ UPISANIH")]
        public BrojUpisanih BrojUpisanih { get; set; }

    }
}