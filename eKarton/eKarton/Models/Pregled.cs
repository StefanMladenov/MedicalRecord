using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models
{
    public class Pregled
    {
        public int PregledID { get; set; }
     
        public ICollection<int> Terapija { get; set; }

        public DateTime Datum { get; set; }

        public string RadnaDijagnoza { get; set; }

        public string AktuelniNalaz { get; set; }
    }
}
