using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMUpisani
{
    public class VMUpisani_Pre
    {
        public IEnumerable<Upisani> IEUpisani { get; set; }


        public Upisani Upisani { get; set; }
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

        public int? StartUpisanihBroj { get; set; }
        public int? EndUpisanihBroj { get; set; }


    }
}