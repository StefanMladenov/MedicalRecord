using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class EKarton
    {
        public int KartonID { get; set; }

        public Lekar Lekar { get; set; }

        public Pacijent Pacijent { get; set; }

        public EKarton KartonOca { get; set; }

        public EKarton KartonMajke { get; set; }

        public List<PregledEntity> PreglediLista { get; set; }

        public KartonAlergena KartonAlergena { get; set; }

        public KartonVakcinacije KartonVakcinacije { get; set; }

        public List<Slika> SlikeLista { get; set; }
    }
}
