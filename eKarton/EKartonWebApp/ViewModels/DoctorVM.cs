using System;
using System.ComponentModel.DataAnnotations;

namespace EKartonWebApp.ViewModels
{
    public class DoctorVM
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [StringLength(13,MinimumLength = 13)]
        public string UniqueCitizensIdentityNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Specialization { get; set; }
    }
}
