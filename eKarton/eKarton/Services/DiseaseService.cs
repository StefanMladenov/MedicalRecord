using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class DiseaseService : IService<Disease>
    {
        private readonly MedicalRecordContext _context;
        public DiseaseService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Disease> GetAll()
        {
            return _context.Diseases.ToList();
        }

        public Disease GetByGuid(string guid)
        {
            return _context.Diseases.Find(guid);
        }

        public List<Disease> GetByCondition(Disease disease)
        {
            throw new NotImplementedException();
        }

        public void Create(Disease obj)
        {
            _context.Diseases.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Disease obj)
        {
            Disease disease = _context.Diseases.Find(guid);
            disease.DiseaseCode = obj.DiseaseCode;
            disease.DiseaseName = obj.DiseaseName;
            disease.Therapy = obj.Therapy;
            disease.DiseaseDiscriminator = obj.DiseaseDiscriminator;
            _context.Diseases.Update(disease);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var disease = _context.Diseases.Find(guid);
            if (disease != null)
            {
                _context.Diseases.Remove(disease);
                _context.SaveChanges();
            }
        }
    }
}
