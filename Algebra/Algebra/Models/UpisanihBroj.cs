using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class UpisanihBroj
    {
        [Key, Column(Order = 0)]
        public int UpisanihBrojID { get; set; }


        [Index("IX_UpisanihBroj1", IsUnique = true)]
        public int Upisani_ID { get; set; }
        public  Upisani Upi { get; set; }


        public int Brojac { get; set; }
    }
}