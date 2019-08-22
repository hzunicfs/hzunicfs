using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMPredbiljezbe
{
    public class VMPredbiljezbe_Log
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Predbiljezba> IEPredbiljezba(VMPredbiljezbe_Pre VMPredbiljezba_Pre)
        {

            


           if (VMPredbiljezba_Pre != null)
            {
                VMPredbiljezba_Pre.IEPredbiljezba = (db.Predbiljezbaa.Where(x => x.Ime == VMPredbiljezba_Pre.Predbiljezba.Ime || VMPredbiljezba_Pre.Predbiljezba.Ime == null)
                                                             .Where(x => x.Prezime== VMPredbiljezba_Pre.Predbiljezba.Prezime || VMPredbiljezba_Pre.Predbiljezba.Prezime == null)
                                                             .Where(x => x.Mjesto_stanovanja == VMPredbiljezba_Pre.Predbiljezba.Mjesto_stanovanja || VMPredbiljezba_Pre.Predbiljezba.Mjesto_stanovanja == null)
                                                             .Where(x => x.Telefon == VMPredbiljezba_Pre.Predbiljezba.Telefon || VMPredbiljezba_Pre.Predbiljezba.Telefon == 0)
                                                             .Where(x => x.Email == VMPredbiljezba_Pre.Predbiljezba.Email|| VMPredbiljezba_Pre.Predbiljezba.Email == null)
                                                             .Where(x => x.Datum_predbiljezbe >= VMPredbiljezba_Pre.StartDatumZ && x.Datum_predbiljezbe <= VMPredbiljezba_Pre.EndDatumZ || VMPredbiljezba_Pre.StartDatumZ == null && VMPredbiljezba_Pre.EndDatumZ == null || x.Datum_predbiljezbe >= VMPredbiljezba_Pre.StartDatumZ && VMPredbiljezba_Pre.EndDatumZ == null || VMPredbiljezba_Pre.StartDatumZ == null && x.Datum_predbiljezbe <= VMPredbiljezba_Pre.EndDatumZ)
                                                             .Where(x => x.Telefon == VMPredbiljezba_Pre.Predbiljezba.OS_ID || VMPredbiljezba_Pre.Predbiljezba.OS_ID == 0)
                                                             ).ToList();
            }

            return VMPredbiljezba_Pre.IEPredbiljezba;
        }
    }
}
