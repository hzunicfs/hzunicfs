using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMPredavac
{
    public class VMPredavac_Pre
    {
        public Predavaci Predavaci { get; set; }
        public Adresepredavaca Adresepredavaca { get; set; }
        public IEnumerable<Predavaci> IEPredavaci { get; set; }
        public IEnumerable<Adresepredavaca> IEAdresepredavaca { get; set; }
    }
}