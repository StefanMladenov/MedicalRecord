using eKarton.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class VaccinationStatusService : IService<VaccinationStatus>
    {
        private readonly MedicalRecordContext _context;
        public VaccinationStatusService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<VaccinationStatus> GetAll()
        {
            return _context.VaccinationStatuses.Include(x => x.Vaccines).ToList();
        }

        public VaccinationStatus GetByGuid(string guid)
        {
            return _context.VaccinationStatuses.Include(x => x.Vaccines).SingleOrDefault(x => x.Guid.Equals(guid));
        }

        public void Create(VaccinationStatus obj)
        {
            _context.VaccinationStatuses.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, VaccinationStatus obj, VaccinationStatus objToUpdate)
        {
            foreach (Vaccine v in objToUpdate.Vaccines)
            {
                _context.Vaccines.Remove(v);
            }
            objToUpdate.Vaccines = new List<Vaccine>();
            if (obj.Vaccines != null)
            {
                foreach (Vaccine v in obj.Vaccines)
                {
                    _context.Vaccines.Add(v);
                    objToUpdate.Vaccines.Add(v);
                }
            }
            _context.VaccinationStatuses.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var vaccinationStatus = GetByGuid(guid);
            if (vaccinationStatus != null)
            {
                if (vaccinationStatus.Vaccines != null && vaccinationStatus.Vaccines.Count != 0)
                {
                    foreach (Vaccine v in vaccinationStatus.Vaccines)
                    {
                        _context.Vaccines.Remove(v);
                    }
                }
                _context.VaccinationStatuses.Remove(vaccinationStatus);
                _context.SaveChanges();
            }
        }
    }
}
