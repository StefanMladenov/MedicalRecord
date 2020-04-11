using System.Collections.Generic;

namespace eMedicalRecord.Models.SQL
{
    public class VaccinationStatus : AbstractEntity
    {
        public List<Vaccine> Vaccines { get; set; }
    }
}
