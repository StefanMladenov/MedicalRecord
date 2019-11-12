using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class KartonAlergena
    {
        public int KartonAlergenaID { get; set; }
        public ICollection<Alergen> AlergeniLista { get; set; }
        public ICollection<Lek> LekoviLista { get; set; }
    }
}
