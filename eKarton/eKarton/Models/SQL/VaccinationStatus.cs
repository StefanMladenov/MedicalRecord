using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class VaccinationStatus : AbstractEntity
    {
        public List<Vaccine> Vaccines { get; set; }
    }
}
