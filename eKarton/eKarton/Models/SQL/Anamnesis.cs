using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class Anamnesis : AbstractEntity
    {
        public List<Disease> Diseases { get; set; }
        public string SocioEpidemiologicalStatus { get; set; }
    }
}
