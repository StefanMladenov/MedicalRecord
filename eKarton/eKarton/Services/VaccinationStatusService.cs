using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class VaccinationStatusService
    {
        private readonly MedicalRecordContext _context;
        public VaccinationStatusService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<VaccinationStatus> GetVaccinationStatuses()
        {
            return _context.VaccinationStatuses.ToList();
        }

        public VaccinationStatus GetVaccinationStatus(int id)
        {
            return _context.VaccinationStatuses.Find(id);
        }

        public void PutVaccinationStatus(int id, VaccinationStatus _vaccinationStatus)
        {
            VaccinationStatus vactionationStatus = _context.VaccinationStatuses.Find(id);
            vactionationStatus.Id = _vaccinationStatus.Id;
            vactionationStatus.VaccineList = _vaccinationStatus.VaccineList;
            _context.VaccinationStatuses.Update(vactionationStatus);
            _context.SaveChanges();
        }

        public void PostVaccinationStatus(VaccinationStatus vaccinationStatus)
        {
            _context.VaccinationStatuses.Add(vaccinationStatus);
            _context.SaveChanges();
        }

        public void DeleteVaccinationStatus(int id)
        {
            var vaccinationStatus = _context.VaccinationStatuses.Find(id);
            if (vaccinationStatus != null)
            {
                _context.VaccinationStatuses.Remove(vaccinationStatus);
            }
            _context.SaveChanges();
        }
    }
}
