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
            return _context.Allergies.Include(x => x.Medicines).SingleOrDefault(x=>x.Guid.Equals(guid));
        }

        public List<Allergy> GetByCondition(Allergy allergy)
        {
            List<Allergy> allergies = new List<Allergy>();
            if (allergy.Medicines.Count != 0)
            {
                allergies = _context.Allergies.Include(x => x.Medicines).Where(x => x.Medicines.All(y => y.NameOfMedicine == allergy.Medicines[0].NameOfMedicine)).ToList();
            }
            return new List<Allergy>();
        }

        public void Create(Allergy obj)
        {
            _context.Allergies.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Allergy obj)
        {
            obj.Guid = guid;
            Allergy allergy = _context.Allergies.Include(x => x.Medicines).SingleOrDefault(x => x.Guid.Equals(guid));
            foreach(string s in obj.Food)
            {
                allergy.Food.Add(s);
            }
            foreach(Medicine med in obj.Medicines)
            {
                if(_context.Medicines.Find(med.Guid) != null)
                {
                    _context.Medicines.Update(med);
                }
                else
                {
                    _context.Medicines.Add(med);
                }
                allergy.Medicines.Add(med);
            }
            foreach (string s in obj.Other)
            {
                allergy.Other.Add(s);
            }
            _context.Allergies.Update(allergy);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var allergy = _context.Allergies.Include(x => x.Medicines).SingleOrDefault(x => x.Guid.Equals(guid));
            if (allergy != null)
            {
                if(allergy.Medicines.Count != 0)
                {
                    foreach(Medicine med in allergy.Medicines)
                    {
                        _context.Medicines.Remove(med);
                    }
                }
                _context.Allergies.Remove(allergy);
                _context.SaveChanges();
            }
            return;
        }
    }
}
