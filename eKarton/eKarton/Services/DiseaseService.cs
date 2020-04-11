using eMedicalRecord.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMedicalRecord.Services
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

        public void Create(Disease obj)
        {
            _context.Diseases.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Disease obj, Disease objToUpdate)
        {
            objToUpdate.DiseaseCode = obj.DiseaseCode;
            objToUpdate.DiseaseName = obj.DiseaseName;
            objToUpdate.Therapy = obj.Therapy;
            objToUpdate.DiseaseDiscriminator = obj.DiseaseDiscriminator;
            _context.Diseases.Update(objToUpdate);
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
