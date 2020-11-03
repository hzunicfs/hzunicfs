using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMOtvoreniSeminari
{
    public class VMOtvoreniSeminari_Log
    {
        private ApplicationDbContext db = new ApplicationDbContext();
   
        public IEnumerable<Otvoreni_seminari> IEOtvoreniseminari(VMOtvoreniSeminari_Pre VMOtvoreniSeminari_Pre)
        {
            
            List<int> OS_ID = (from k in db.BrojUpisanihh
                               where k.Brojac >= VMOtvoreniSeminari_Pre.StartBrojUpisanih&& k.Brojac <= VMOtvoreniSeminari_Pre.EndBrojUpisanih
                               select k.OS_ID).ToList();


            if (VMOtvoreniSeminari_Pre != null )
            {
                VMOtvoreniSeminari_Pre.IEOtvoreniseminari = (db.Otvoreni_seminarii.Where(x => x.OS_ID == VMOtvoreniSeminari_Pre.Otvoreniseminari.OS_ID || VMOtvoreniSeminari_Pre.Otvoreniseminari.OS_ID==0)
                                                             .Where(x => x.Broj_polaznika == VMOtvoreniSeminari_Pre.Otvoreniseminari.Broj_polaznika || VMOtvoreniSeminari_Pre.Otvoreniseminari.Broj_polaznika == 0)
                                                             .Where(x => x.Seminar_ID == VMOtvoreniSeminari_Pre.Otvoreniseminari.Seminar_ID || VMOtvoreniSeminari_Pre.Otvoreniseminari.Seminar_ID == 0)
                                                             .Where(x => x.Datum_pocetka >= VMOtvoreniSeminari_Pre.StartDatumP && x.Datum_pocetka <= VMOtvoreniSeminari_Pre.EndDatumP || VMOtvoreniSeminari_Pre.StartDatumP == null && VMOtvoreniSeminari_Pre.EndDatumP == null || x.Datum_pocetka >= VMOtvoreniSeminari_Pre.StartDatumP && VMOtvoreniSeminari_Pre.EndDatumP == null || VMOtvoreniSeminari_Pre.StartDatumP == null && x.Datum_pocetka <= VMOtvoreniSeminari_Pre.EndDatumP)
                                                             .Where(x => x.Datum_zavrsetka >= VMOtvoreniSeminari_Pre.StartDatumZ && x.Datum_zavrsetka <= VMOtvoreniSeminari_Pre.EndDatumZ || VMOtvoreniSeminari_Pre.StartDatumZ == null && VMOtvoreniSeminari_Pre.EndDatumZ == null || x.Datum_zavrsetka >= VMOtvoreniSeminari_Pre.StartDatumZ && VMOtvoreniSeminari_Pre.EndDatumZ == null || VMOtvoreniSeminari_Pre.StartDatumZ == null && x.Datum_zavrsetka <= VMOtvoreniSeminari_Pre.EndDatumZ)
                                                             .Where(x => x.AO_ID == VMOtvoreniSeminari_Pre.Otvoreniseminari.AO_ID || VMOtvoreniSeminari_Pre.Otvoreniseminari.AO_ID == 0)
                                                             .Where(x => x.Predavaci_ID == VMOtvoreniSeminari_Pre.Otvoreniseminari.Predavaci_ID || VMOtvoreniSeminari_Pre.Otvoreniseminari.Predavaci_ID == 0)
                                                             .Where(x => x.Broj_polaznika >= VMOtvoreniSeminari_Pre.StartBrojP && x.Broj_polaznika <= VMOtvoreniSeminari_Pre.EndBrojP || VMOtvoreniSeminari_Pre.StartBrojP == null && VMOtvoreniSeminari_Pre.EndBrojP == null || x.Broj_polaznika >= VMOtvoreniSeminari_Pre.StartBrojP && VMOtvoreniSeminari_Pre.EndBrojP == null || VMOtvoreniSeminari_Pre.StartBrojP == null && x.Broj_polaznika <= VMOtvoreniSeminari_Pre.EndBrojP)
                                                             .Where(x => x.Broj_polaznika >= VMOtvoreniSeminari_Pre.StartBrojP && x.Broj_polaznika <= VMOtvoreniSeminari_Pre.EndBrojP || VMOtvoreniSeminari_Pre.StartBrojP == null && VMOtvoreniSeminari_Pre.EndBrojP == null || x.Broj_polaznika >= VMOtvoreniSeminari_Pre.StartBrojP && VMOtvoreniSeminari_Pre.EndBrojP == null || VMOtvoreniSeminari_Pre.StartBrojP == null && x.Broj_polaznika <= VMOtvoreniSeminari_Pre.EndBrojP)
                                                             .Where(x => OS_ID.Contains(x.OS_ID) && OS_ID.Any() || VMOtvoreniSeminari_Pre.StartBrojUpisanih==null && VMOtvoreniSeminari_Pre.EndBrojUpisanih==null)
                                                             ).ToList();
            }
           
            return VMOtvoreniSeminari_Pre.IEOtvoreniseminari;
        }
    }
}