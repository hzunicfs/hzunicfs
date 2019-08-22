using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMSeminari
{
    public class VMSeminari_Log
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Seminari> IESeminari(VMSeminari_Pre VMSeminari_Pre)
        {
            
            if (VMSeminari_Pre != null)
            {
                VMSeminari_Pre.IESeminari = (db.Seminarii.Where(x => x.Seminar_ID == VMSeminari_Pre.Seminari.Seminar_ID || VMSeminari_Pre.Seminari.Seminar_ID==0)
                                                      .Where(x => x.Naziv == VMSeminari_Pre.Seminari.Naziv || VMSeminari_Pre.Seminari.Naziv==null)).ToList();
            }
            return VMSeminari_Pre.IESeminari;
        }
                
 
       
    }
}