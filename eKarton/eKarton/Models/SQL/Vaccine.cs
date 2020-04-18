using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class Vaccine : AbstractEntity
    {
        [Required]
        public string VaccineSerialMark { get; set; }

        [Required]
        public string VaccineName { get; set; }

        public int Duration { get; set; }
    }
}
