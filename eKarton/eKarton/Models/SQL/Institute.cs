using System.Collections.Generic;

namespace eMedicalRecord.Models.SQL
{
    public class Institute : AbstractEntity
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
