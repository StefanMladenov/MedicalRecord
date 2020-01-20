using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Models.SQL
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DiseaseCode { get; set; }
        public string DiseaseName { get; set; }
        public string Therapy { get; set; }
        public DiseaseDiscriminator DiseaseDiscriminator { get; set; }
    }

    public enum DiseaseDiscriminator
    {
        CURRENT,
        MOVED,
        FAMILY
    }
}
