using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eKarton.Services
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

        public List<Vaccine> GetByCondition(Vaccine vaccine)
        {
            throw new NotImplementedException();
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

        public void Update(string guid, Vaccine obj)
        {
            Vaccine vaccine = _context.Vaccines.Find(guid);
            /*            vaccine.Id = _vaccine.Id;
                        vaccine.Duration = _vaccine.Duration;
                        vaccine.VaccinationDate = _vaccine.VaccinationDate;
                        vaccine.VaccineName = _vaccine.VaccineName;*/
            vaccine = obj;
            _context.Vaccines.Update(vaccine);
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
