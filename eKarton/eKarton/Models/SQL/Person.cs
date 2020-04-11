using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalRecord.Models.SQL
{
    public abstract class Person : AbstractEntity
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string UniqueCitizensIdentityNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string EMail { get; set; }

    }
}
