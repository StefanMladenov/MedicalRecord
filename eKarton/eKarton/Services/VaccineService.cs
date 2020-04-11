using eMedicalRecord.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMedicalRecord.Services
{
    public class VaccineService : IService<Vaccine>
    {
        private readonly MedicalRecordContext _context;
        public VaccineService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Vaccine> GetAll()
        {
            return _context.Vaccines.ToList();
        }

        public Vaccine GetByGuid(string guid)
        {
            return _context.Vaccines.Find(guid);
        }

        public void Create(Vaccine obj)
        {
            if (obj.Guid != null)
            {
                obj.Guid = Guid.NewGuid().ToString();
            }
            obj.CreatedAt = DateTime.Now;
            _context.Vaccines.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Vaccine obj, Vaccine objToUpdate)
        {
            objToUpdate.Duration = obj.Duration;
            objToUpdate.VaccineName = obj.VaccineName;
            objToUpdate.VaccineSerialMark = obj.VaccineSerialMark;
            _context.Vaccines.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var vaccine = _context.Vaccines.Find(guid);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
            }
            _context.SaveChanges();
        }

    }
}
