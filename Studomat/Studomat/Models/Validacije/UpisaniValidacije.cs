using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Algebra.Models.Validacije
{


    public class EmailUpisaniAttribute : ValidationAttribute
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        
        public override bool IsValid(object value)
        {
           
            if (value is VMUpisani VMUpisani&& VMUpisani.Upisani!=null)
            {
               
                var pre = db.Upisanii.ToList().FirstOrDefault(x => x.Email == VMUpisani.Upisani.Email && x.Upisani_ID != VMUpisani.Upisani.Upisani_ID);
                if (pre == null)
                {
                    return true;
                }
                else
                { return false; }
            }
            return true;
        }

    }

    public class OIBUpisaniAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
            if (value is VMUpisani VMUpisani && VMUpisani.Upisani != null)
            {
                var pre = db.Upisanii.FirstOrDefault(x => x.OIB == VMUpisani.Upisani.OIB && x.Upisani_ID != VMUpisani.Upisani.Upisani_ID);
                if (pre == null)
                {
                    return true;

                }
                return false;
            }

            return true;

        }

    }






    public class OsobnaUpisaniAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
            if (value is VMUpisani VMUpisani && VMUpisani.Upisani != null)
            {
                var pre = db.Upisanii.FirstOrDefault(x => x.Broj_osobne == VMUpisani.Upisani.Broj_osobne && x.Upisani_ID != VMUpisani.Upisani.Upisani_ID);
                if (pre == null)
                {
                    return true;

                }
                else
                { return false; }
            }
            return true;
        }

    }


}


      
    







