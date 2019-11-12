using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class KartonVakcinacije
    {
        public int KartonVakcinacijeID { get; set; }
        public ICollection<Vakcina> VakcineLista { get; set; }
    }
}
