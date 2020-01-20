using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKarton.Models.SQL
{
    public class MedicalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public MedicalRecord FathersMedicalRecord { get; set; }
        public MedicalRecord MothersMedicalRecord { get; set; }
        public ICollection<VisitEntity> Visits { get; set; }
        public Allergy Allergy { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }
        public ICollection<Image> Images { get; set; }
        public Anamnesis Anamnesis { get; set; }
    }
}
