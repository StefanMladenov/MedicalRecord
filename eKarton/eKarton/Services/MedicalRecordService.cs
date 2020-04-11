using eMedicalRecord.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMedicalRecord.Services
{
    public class MedicalRecordService : IService<MedicalRecord>
    {
        private readonly MedicalRecordContext _context;

        public MedicalRecordService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<MedicalRecord> GetAll()
        {
            return _context.MedicalRecords.ToList();
        }

        public MedicalRecord GetByGuid(string guid)
        {
            return _context.MedicalRecords.Find(guid);
        }

        public void Create(MedicalRecord obj)
        {
            _context.MedicalRecords.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, MedicalRecord obj, MedicalRecord objToUpdate)
        {


            
            _context.MedicalRecords.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var medicalRecord = _context.MedicalRecords.Find(guid);
            if (medicalRecord != null)
            {
                _context.MedicalRecords.Remove(medicalRecord);
            }
            _context.SaveChanges();
        }
    }
}

