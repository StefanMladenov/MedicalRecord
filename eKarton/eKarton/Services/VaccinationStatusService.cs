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

        public void Update(string guid, VaccinationStatus obj, VaccinationStatus objToUpdate)
        {
            foreach(Vaccine v in objToUpdate.Vaccines)
            {
                _context.Vaccines.Remove(v);
            }
            objToUpdate.Vaccines = new List<Vaccine>();
            foreach(Vaccine v in obj.Vaccines)
            {
                objToUpdate.Vaccines.Add(v);
            }
            _context.VaccinationStatuses.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var vaccinationStatus = _context.VaccinationStatuses.Find(guid);
            if (vaccinationStatus != null)
            {
                if(vaccinationStatus.Vaccines.Count != 0)
                {
                    foreach(Vaccine v in vaccinationStatus.Vaccines)
                    {
                        _context.Vaccines.Remove(v);
                    }
                }
                _context.VaccinationStatuses.Remove(vaccinationStatus);
            }
            _context.SaveChanges();
        }
    }
}
