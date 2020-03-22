using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class MedicalRecord : AbstractEntity
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public MedicalRecord FathersMedicalRecord { get; set; }
        public MedicalRecord MothersMedicalRecord { get; set; }
        public Allergy Allergy { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }
        public ICollection<Image> Images { get; set; }
        public List<string> Visits { get; set; }
        public Anamnesis Anamnesis { get; set; }
    }
}
