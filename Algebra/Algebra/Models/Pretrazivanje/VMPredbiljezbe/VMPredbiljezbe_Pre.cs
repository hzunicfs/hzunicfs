using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Algebra.Models.Pretrazivanje.VMPredbiljezbe
{
    public class VMPredbiljezbe_Pre
    {
        public Predbiljezba Predbiljezba { get; set; }
        public IEnumerable<Predbiljezba> IEPredbiljezba { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDatumZ { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDatumZ { get; set; }
    }
}