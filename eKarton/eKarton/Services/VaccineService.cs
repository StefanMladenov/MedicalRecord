using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class VaccineService
    {
        private readonly MedicalRecordContext _context;
        public VaccineService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Vaccine> GetVaccines()
        {
            return _context.Vaccines.ToList();
        }

        public Vaccine GetVaccine(int id)
        {
            return _context.Vaccines.Find(id);
        }

        public void PutVaccine(int id, Vaccine _vaccine)
        {
            Vaccine vaccine = _context.Vaccines.Find(id);
            vaccine.Id = _vaccine.Id;
            vaccine.Duration = _vaccine.Duration;
            vaccine.VaccinationDate = _vaccine.VaccinationDate;
            vaccine.VaccineName = _vaccine.VaccineName;
            _context.Vaccines.Update(vaccine);
            _context.SaveChanges();
        }

        public void PostVaccine(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
        }

        public void DeleteVaccine(int id)
        {
            var vaccine = _context.Vaccines.Find(id);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
            }
            _context.SaveChanges();
        }
    }
}
