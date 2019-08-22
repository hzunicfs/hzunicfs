using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    
    public class Adrese_upisanih
    {
        [Key]
       
        public string Id_Adresa { get; set; }


        public string Ulica {get; set;}

        public string Kucni_broj { get; set; }

        public string Postanski_broj { get; set; }

        public string Grad { get; set; }

        public string Drzava { get; set; }

    }
}