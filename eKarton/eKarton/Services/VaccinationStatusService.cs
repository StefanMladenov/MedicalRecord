using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            return _context.VaccinationStatuses.ToList();
        }

        public VaccinationStatus GetByGuid(string guid)
        {
            return _context.VaccinationStatuses.Find(guid);
        }

        public List<VaccinationStatus> GetByCondition(VaccinationStatus vaccination)
        {
            throw new NotImplementedException();
        }

        public void Create(VaccinationStatus obj)
        {
            if (obj.Guid != null)
            {
                obj.Guid = Guid.NewGuid().ToString();
            }
            obj.CreatedAt = DateTime.Now;
            _context.VaccinationStatuses.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, VaccinationStatus obj)
        {
            VaccinationStatus vactionationStatus = _context.VaccinationStatuses.Find(guid);
            /*            vactionationStatus.Id = _vaccinationStatus.Id;
                        vactionationStatus.VaccineList = _vaccinationStatus.VaccineList;*/
            vactionationStatus = obj;
            _context.VaccinationStatuses.Update(vactionationStatus);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var vaccinationStatus = _context.VaccinationStatuses.Find(guid);
            if (vaccinationStatus != null)
            {
                _context.VaccinationStatuses.Remove(vaccinationStatus);
            }
            _context.SaveChanges();
        }
    }
}
