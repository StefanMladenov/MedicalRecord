using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class Allergy : AbstractEntity
    {
        public List<string> Food { get; set; }
        public List<Medicine> Medicines { get; set; }
        public List<string> Other { get; set; }
    }
}
