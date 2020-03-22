using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class MedicineService : IService<Medicine>
    {
        private readonly MedicalRecordContext _context;
        public MedicineService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Medicine> GetAll()
        {
            return _context.Medicines.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public Medicine GetByGuid(string guid)
        {
            return _context.Medicines.Find(guid);
        }

        public List<Medicine> GetByCondition(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void Create(Medicine obj)
        {
            _context.Medicines.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Medicine obj)
        {
            Medicine medicine = _context.Medicines.Find(guid);
            medicine.NameOfMedicine = obj.NameOfMedicine;
            medicine.Allergic = obj.Allergic;
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var medicine = _context.Medicines.Find(guid);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
            }
            _context.SaveChanges();
        }
    }
}
