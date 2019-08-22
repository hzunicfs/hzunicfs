using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class VMPredbiljezba
    { public Predbiljezba Predbiljezba { get; set; }
      public IEnumerable<Predbiljezba> IEPredbiljezba { get;set;}
    }
}