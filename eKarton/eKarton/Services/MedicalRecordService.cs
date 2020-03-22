using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eKarton.Services
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

        public List<MedicalRecord> GetByCondition(MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }

        public void Create(MedicalRecord obj)
        {
            if (obj.Guid != null)
            {
                obj.Guid = Guid.NewGuid().ToString();
            }
            obj.CreatedAt = DateTime.Now;
            _context.MedicalRecords.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, MedicalRecord obj)
        {
            MedicalRecord medicalRecord = _context.MedicalRecords.Find(guid);
            /*            medicalRecord.Id = _medicalRecord.Id;
                        medicalRecord.Allergy = _medicalRecord.Allergy;
                        medicalRecord.Anamnesis = _medicalRecord.Anamnesis;
                        medicalRecord.Doctor = _medicalRecord.Doctor;
                        medicalRecord.FathersMedicalRecord = _medicalRecord.FathersMedicalRecord;
                        medicalRecord.MothersMedicalRecord = _medicalRecord.MothersMedicalRecord;
                        medicalRecord.Patient = _medicalRecord.Patient;
                        medicalRecord.VaccinationStatus = _medicalRecord.VaccinationStatus;
                        medicalRecord.Visits = _medicalRecord.Visits;
                        medicalRecord.Images = _medicalRecord.Images;*/
            medicalRecord = obj;
            _context.MedicalRecords.Update(medicalRecord);
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

