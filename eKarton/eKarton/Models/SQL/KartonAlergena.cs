using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class KartonAlergena
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<string>  Hrana { get; set; }
        public ICollection<Lek> Lekovi { get; set; }
        public List<string> Ostalo { get; set; }
    }
}
