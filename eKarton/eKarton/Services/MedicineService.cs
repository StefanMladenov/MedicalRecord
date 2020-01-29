using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class MedicineService
    {
        private readonly MedicalRecordContext _context;
        public MedicineService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Medicine> GetMedicines()
        {
            return _context.Medicines.ToList();
        }

        public Medicine GetMedicine(int id)
        {
            return _context.Medicines.Find(id);
        }

        public void PutMedicine(int id, Medicine _medicine)
        {
            Medicine medicine = _context.Medicines.Find(id);
            medicine.Id = _medicine.Id;
            medicine.NameOfMedicine = _medicine.NameOfMedicine;
            medicine.Allergic = _medicine.Allergic;
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }

        public void PostMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }

        public void DeleteMedicine(int id)
        {
            var medicine = _context.Medicines.Find(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
            }
            _context.SaveChanges();
        }
    }
}
