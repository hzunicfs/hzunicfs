using Algebra.Models.Validacije;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    [EmailPredavac(ErrorMessage = "Predavač sa tim  Email-om već postoji.")]
    [OIBPredavac(ErrorMessage = "Predavač sa tim OIB-om već postoji.Klikni za detalje.")]
    [OsobnaPredavac(ErrorMessage = "Predavač sa tim brojem osobne iskaznice već postoji.Klikni za detalje.")]
    public class VMPredavac
    {
        
        public Predavaci Predavaci { get; set; }
        public Adresepredavaca Adresepredavaca { get; set; }
        public IEnumerable<Predavaci> IEPredavaci { get; set; }
        public IEnumerable<Adresepredavaca> IEAdresepredavaca { get; set; }


    }
}