using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models
{
    public class Pregled
    {

        public int Pregled_id { get; set; }
        public string Izvestaj_pisano { get; set; }

        public DateTime Datum { get; set; }

        public string Terapija { get; set; }

        public Array Slike { get; set; }
    }
}
