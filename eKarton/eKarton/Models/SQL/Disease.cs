using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class Disease : AbstractEntity
    {
        [Required]
        public string DiseaseCode { get; set; }
        [Required]
        public string DiseaseName { get; set; }
        public string Therapy { get; set; }
        public DiseaseDiscriminator DiseaseDiscriminator { get; set; }
    }

    public enum DiseaseDiscriminator
    {
        CURRENT = 1,
        MOVED = 2,
        FAMILY = 3
    }
}
