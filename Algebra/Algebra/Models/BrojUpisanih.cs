using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class BrojUpisanih
    {
        [Key, Column(Order = 0)]
        public int BrojUpisanihID { get; set; }

        [Index("IX_BrojUpisanih1", IsUnique = true)]
        public int OS_ID { get; set; }
        public Otvoreni_seminari Otvoreni { get; set; }


        public int Brojac { get; set; }
    }
}