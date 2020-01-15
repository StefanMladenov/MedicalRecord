using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models.SQL
{
    public class Bolest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SifraBolesti { get; set; }
        public string NazivBolesti { get; set; }
        public string Terapija { get; set; }

        //public ICollection<Anamneza> Anamneza{ get; set; }
        public BolestDiskriminator BolestDiskriminator { get; set; }
    }

    public enum BolestDiskriminator
    {
        AKTUELNA,
        PRELEZANA,
        PORODICNA
    }
}
