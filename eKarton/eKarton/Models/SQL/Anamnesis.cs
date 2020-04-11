using System.Collections.Generic;

namespace eMedicalRecord.Models.SQL
{
    public class Anamnesis : AbstractEntity
    {
        public List<Disease> Diseases { get; set; }
        public string SocioEpidemiologicalStatus { get; set; }
    }
}
