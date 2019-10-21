using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models
{
    public class eKarton
    {
        public int Karton_id { get; set; }

        public string Ime_prezime { get; set; }

        public string JMBG { get; set; }

        public int Lekar_id { get; set; }
        
        public string Grad { get; set; }

    }
}
