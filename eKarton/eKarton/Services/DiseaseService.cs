using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class DiseaseService
    {
        private readonly MedicalRecordContext _context;
        public DiseaseService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Disease> GetDiseases()
        {
            return _context.Diseases.ToList();
        }

        public Disease GetDisease(int id)
        {
            return _context.Diseases.Find(id);
        }

        public void PutDisease(int id, Disease _disease)
        {
            Disease disease = _context.Diseases.Find(id);
            disease.DiseaseCode = _disease.DiseaseCode;
            disease.DiseaseName = _disease.DiseaseName;
            disease.Therapy = _disease.Therapy;
            disease.Id = _disease.Id;
            disease.DiseaseDiscriminator = _disease.DiseaseDiscriminator;
            _context.Diseases.Update(disease);
            _context.SaveChanges();
        }

        public void PostDisease(Disease disease)
        {
            _context.Diseases.Add(disease);
            _context.SaveChanges();
        }

        public void DeleteDisease(int id)
        {
            var disease = _context.Diseases.Find(id);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
            }
            _context.SaveChanges();
        }
    }
}
