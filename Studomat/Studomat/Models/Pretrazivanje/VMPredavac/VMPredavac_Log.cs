using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMPredavac
{
    public class VMPredavac_Log
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Predavaci> IEPredavaci(VMPredavac_Pre VMPredavac_Pre)
        {
            List<int> AP_ID = (from k in db.Adrese_predavacaa
                               where k.Grad == VMPredavac_Pre.Adresepredavaca.Grad
                               select k.AP_ID).ToList();
            if (VMPredavac_Pre != null)
            {
                VMPredavac_Pre.IEPredavaci = (db.Predavacii.Where(x => x.Ime == VMPredavac_Pre.Predavaci.Ime || VMPredavac_Pre.Predavaci.Ime == null)
                                                      .Where(x => x.Prezime == VMPredavac_Pre.Predavaci.Prezime || VMPredavac_Pre.Predavaci.Prezime == null)
                                                      .Where(x => x.OIB == VMPredavac_Pre.Predavaci.OIB|| VMPredavac_Pre.Predavaci.OIB == null)
                                                      .Where(x => x.Broj_osobne == VMPredavac_Pre.Predavaci.Broj_osobne || VMPredavac_Pre.Predavaci.Broj_osobne == null)
                                                      .Where(x => x.Email == VMPredavac_Pre.Predavaci.Email || VMPredavac_Pre.Predavaci.Email == null)
                                                      .Where(x => x.Telefon == VMPredavac_Pre.Predavaci.Telefon || VMPredavac_Pre.Predavaci.Telefon == 0)
                                                     .Where(x => AP_ID.Contains(x.AP_ID) && VMPredavac_Pre.Adresepredavaca.Grad != null || VMPredavac_Pre.Adresepredavaca.Grad == null)
                                                      ).ToList();
            }
            return VMPredavac_Pre.IEPredavaci;
        }

    }
}