
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models
{





    public class OIBPredavacAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
            if (value is VMPredavac PredavacIAdresa)
            {
                var pre = db.Predavacii.FirstOrDefault(x => x.OIB == PredavacIAdresa.Predavaci.OIB && x.Predavaci_ID != PredavacIAdresa.Predavaci.Predavaci_ID);
                if (pre == null)
                {
                    return true;
                }
            }
            return false;

        }

    }


    public class EmailPredavacAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
            if (value is VMPredavac PredavacIAdresa)
            {
                var pre = db.Predavacii.FirstOrDefault(x => x.Email == PredavacIAdresa.Predavaci.Email && x.Predavaci_ID != PredavacIAdresa.Predavaci.Predavaci_ID);
                if (pre == null)
                {
                    return true;

                }
            }

            return false;

        }
    }

    public class OsobnaPredavacAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
            if (value is VMPredavac PredavacIAdresa)
            {
                var pre = db.Predavacii.FirstOrDefault(x => x.Broj_osobne == PredavacIAdresa.Predavaci.Broj_osobne && x.Predavaci_ID != PredavacIAdresa.Predavaci.Predavaci_ID);
                if (pre == null)
                {
                    return true;

                }
            }

            return false;

        }

    }
}
    