using Algebra.Models.Validacije;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
   
    public class Upisi
    {        [Key,Column(Order=0)]
             public int Upisani_ID { get; set; }
             public Upisani Upisani { get; set; }

        [Key, Column(Order = 1)]
        public int OS_ID { get; set; }
        public Otvoreni_seminari Otvoreni { get; set; }

     
        
    }
}