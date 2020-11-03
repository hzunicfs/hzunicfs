using Algebra.Models.Pretrazivanje.VMUpisani;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMUpisani
{
    public class VMUpisani_Log
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        public IEnumerable<Upisani> IEUpisani(VMUpisani_Pre VMUpisani_Pre)
        {
            List<int> AU_ID = (from k in db.Adrese_upisanihh
                               where k.Grad == VMUpisani_Pre.Adreseupisanih.Grad
                               select k.AU_ID).ToList();

            List<int> Upisani_ID = (from k in db.UpisanihBrojj
                               where k.Brojac >= VMUpisani_Pre.StartUpisanihBroj && k.Brojac <= VMUpisani_Pre.EndUpisanihBroj
                               select k.Upisani_ID).ToList();

            VMUpisani_Pre.IEUpisani = (db.Upisanii.Where(x => x.Ime == VMUpisani_Pre.Upisani.Ime || VMUpisani_Pre.Upisani.Ime == null)
                                              .Where(x => x.Prezime == VMUpisani_Pre.Upisani.Prezime || VMUpisani_Pre.Upisani.Prezime == null)
                                              .Where(x => x.OIB == VMUpisani_Pre.Upisani.OIB || VMUpisani_Pre.Upisani.OIB == null)
                                              .Where(x => x.Prezime == VMUpisani_Pre.Upisani.Broj_osobne || VMUpisani_Pre.Upisani.Broj_osobne == null)
                                              .Where(x => AU_ID.Contains(x.AU_ID) && VMUpisani_Pre.Adreseupisanih.Grad != null || VMUpisani_Pre.Adreseupisanih.Grad == null)
                                            .Where(x =>Upisani_ID.Contains(x.Upisani_ID) && Upisani_ID.Any() || VMUpisani_Pre.StartUpisanihBroj == null && VMUpisani_Pre.EndUpisanihBroj == null)).ToList();

            return VMUpisani_Pre.IEUpisani;
        }

        




    }
}