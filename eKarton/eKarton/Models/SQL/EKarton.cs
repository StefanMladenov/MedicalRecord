using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class EKarton
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Lekar Lekar { get; set; }
        public Pacijent Pacijent { get; set; }
        public EKarton KartonOca { get; set; }
        public EKarton KartonMajke { get; set; }
        public ICollection<PregledEntity> PreglediLista { get; set; }
        public KartonAlergena KartonAlergena { get; set; }
        public KartonVakcinacije KartonVakcinacije { get; set; }
        public ICollection<Slika> SlikeLista { get; set; }
        public Anamneza Anamneza { get; set; }
    }
}
