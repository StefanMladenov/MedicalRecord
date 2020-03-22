using System;
using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class Vaccine : AbstractEntity
    {
        [Required]
        public string VaccineSerialMark { get; set; }

        [Required]
        public string VaccineName { get; set; }
        
        //if trajanje==null then neograniceno else dani
        public int Duration { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of vaccination")]
        public DateTime VaccinationDate { get; set; }
    }
}
