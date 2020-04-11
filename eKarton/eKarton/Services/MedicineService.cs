using eMedicalRecord.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMedicalRecord.Services
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

        public void Create(Medicine obj)
        {
            _context.Medicines.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Medicine obj, Medicine objToUpdate)
        {
            objToUpdate.NameOfMedicine = obj.NameOfMedicine;
            objToUpdate.Allergic = obj.Allergic;
            _context.Medicines.Update(objToUpdate);
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
