using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Ustanova
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public ICollection<Lekar> Lekari { get; set; }
    }
}
