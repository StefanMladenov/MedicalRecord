using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eKarton.Models.SQL
{
    public class MedicalRecord : AbstractEntity
    {
        public Doctor Doctor { get; set; }
        [Required]
        public Patient Patient { get; set; }
        public Allergy Allergy { get; set; }
        public Anamnesis Anamnesis { get; set; }
        public List<Analysis> Analysis { get; set; }
        public List<Instruction> Instructions { get; set; }
        public List<Snapshot> Snapshots { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }
        public List<string> VisitGuids { get; set; }
        
    }
}
