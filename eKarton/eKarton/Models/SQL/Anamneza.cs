using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Anamneza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Bolest> Bolesti { get; set; }
        //public Bolest AktuelnaBolest { get; set; }
        //public ICollection<Bolest> PorodicneBolesti { get; set; }
        public string SocioEpidemioloskiStatus { get; set; }
    }
}
