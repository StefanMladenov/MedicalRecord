using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class AllergyService
    {
        private readonly MedicalRecordContext _context;
        public AllergyService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Allergy> GetAllergies()
        {
            return _context.Allergies.ToList();
        }

        public Allergy GetAllergy(int id)
        {
            return _context.Allergies.Find(id);
        }

        public void PutAllergy(int id, Allergy _allergy)
        {
            Allergy allergy = _context.Allergies.Find(id);
            allergy.Id = _allergy.Id;
            allergy.Medicines = _allergy.Medicines;
            allergy.Other = _allergy.Other;
            allergy.Food = _allergy.Food;
            _context.Allergies.Update(allergy);
            _context.SaveChanges();
        }

        public void PostAllergy(Allergy allergy)
        {
            _context.Allergies.Add(allergy);
            _context.SaveChanges();
        }

        public void DeleteAllergy(int id)
        {
            var allergy = _context.Allergies.Find(id);
            if (allergy != null)
            {
                _context.Allergies.Remove(allergy);
            }
            _context.SaveChanges();
        }
    }
}
