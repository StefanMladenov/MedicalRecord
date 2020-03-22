using System;
using System.ComponentModel.DataAnnotations;

namespace EKartonWebApp.ViewModels
{
    public class PatientVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+[0-9]*$")]
        [StringLength(13, MinimumLength = 13)]
        public string UniqueCitizensIdentityNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        // 1 - male , 2 - female
        public int Gender { get; set; }
        public int HealthInsuranceNumber { get; set; }
        // 1 - public, 2 - private
        public int TypeOfInsurance { get; set; }
    }
}
