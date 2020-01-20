using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string UniqueCitizensIdentityNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public string EMail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
    public class Doctor : Person
    {
        public string Specialization { get; set; }
        public Institute Institute { get; set; }
        public int FacsimileNumber { get; set; }
    }

    public class Patient : Person
    {
        public string FathersName { get; set; }
        public string MothersName { get; set; }

        // 1 - male , 2 - female
        public int Gender { get; set; }
        public int HealthInsuranceNumber { get; set; }

        // 1 - public, 2 - private
        public int TypeOfInsurance { get; set; }
    }
}
