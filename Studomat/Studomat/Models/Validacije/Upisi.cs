using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models.Validacije
{
    public class UpisiiiAttribute : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override bool IsValid(object value)
        {
          
            if (value is VMUpisani VMUpisani)
            {
                var pre = db.Upisii.ToList().FirstOrDefault(x => x.Upisani_ID == VMUpisani.Upisi.Upisani_ID && x.OS_ID == VMUpisani.Upisi.OS_ID);
                if (pre == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }

    }

}