using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(Vaccine obj)
        {
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
            var vaccine = GetByGuid(guid);
            if (vaccine != null)
            {
                _context.Vaccines.Remove(vaccine);
                _context.SaveChanges();
            }
        }
    }
}
