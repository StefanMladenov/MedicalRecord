using eKarton.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class AllergyService : IService<Allergy>
    {
        private readonly MedicalRecordContext _context;
        public AllergyService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Allergy> GetAll()
        {
            return _context.Allergies.Include(x => x.Medicines).ToList();
        }

        public Allergy GetByGuid(string guid)
        {
            return _context.Allergies.Include(x => x.Medicines).SingleOrDefault(x => x.Guid.Equals(guid));
        }

        public void Create(Allergy obj)
        {
            _context.Allergies.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Allergy obj, Allergy objToUpdate)
        {
            foreach (Medicine m in objToUpdate.Medicines)
            {
                _context.Medicines.Remove(m);
            }
            objToUpdate.Food = new List<string>();
            objToUpdate.Medicines = new List<Medicine>();
            objToUpdate.Other = new List<string>();
            foreach (string s in obj.Food)
            {
                objToUpdate.Food.Add(s);
            }
            if (obj.Medicines != null)
            {
                foreach (Medicine med in obj.Medicines)
                {
                    _context.Medicines.Add(med);
                    objToUpdate.Medicines.Add(med);
                }
            }
            foreach (string s in obj.Other)
            {
                objToUpdate.Other.Add(s);
            }
            _context.Allergies.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var allergy = _context.Allergies.Include(x => x.Medicines).SingleOrDefault(x => x.Guid.Equals(guid));
            if (allergy != null)
            {
                if (allergy.Medicines != null && allergy.Medicines.Count != 0)
                {
                    foreach (Medicine med in allergy.Medicines)
                    {
                        _context.Medicines.Remove(med);
                    }
                }
                _context.Allergies.Remove(allergy);
                _context.SaveChanges();
            }
        }
    }
}
