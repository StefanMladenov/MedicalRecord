using System.Collections.Generic;

namespace eMedicalRecord.Models.SQL
{
    public class Allergy : AbstractEntity
    {
        public List<string> Food { get; set; }
        public List<Medicine> Medicines { get; set; }
        public List<string> Other { get; set; }
    }
}
