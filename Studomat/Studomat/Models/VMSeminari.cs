using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models
{
    public class VMSeminari
    { public Seminari Seminari { get; set; }
      public IEnumerable<Seminari> IESeminari { get; set; }
    }
}