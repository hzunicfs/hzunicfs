using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMSeminari
{
    public class VMSeminari_Pre
    {
        public Seminari Seminari { get; set; }
        public IEnumerable<Seminari> IESeminari { get; set; }
    }
}