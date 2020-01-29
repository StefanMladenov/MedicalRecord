using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Services
{
    public class MedicalRecordService
    {
        private readonly MedicalRecordContext _context;

        public MedicalRecordService(MedicalRecordContext context)
        {
            _context = context;
        }

        // GET: api/EKarton
        public List<MedicalRecord> GetMedicalRecords()
        {
            return _context.MedicalRecords.ToList();
        }

        // GET: api/EKarton/5
        public MedicalRecord GetMedicalRecord(int id)
        {
            MedicalRecord medicalRecord = _context.MedicalRecords.Find(id);
            if (medicalRecord != null)
            {
                return medicalRecord;
            }
            return medicalRecord;
        }
        public void PutMedicalRecord(int id, MedicalRecord _medicalRecord)
        {
            MedicalRecord medicalRecord = _context.MedicalRecords.Find(id);
            medicalRecord.Id = _medicalRecord.Id;
            medicalRecord.Allergy = _medicalRecord.Allergy;
            medicalRecord.Anamnesis = _medicalRecord.Anamnesis;
            medicalRecord.Doctor = _medicalRecord.Doctor;
            medicalRecord.FathersMedicalRecord = _medicalRecord.FathersMedicalRecord;
            medicalRecord.MothersMedicalRecord = _medicalRecord.MothersMedicalRecord;
            medicalRecord.Patient = _medicalRecord.Patient;
            medicalRecord.VaccinationStatus = _medicalRecord.VaccinationStatus;
            medicalRecord.Visits = _medicalRecord.Visits;
            medicalRecord.Images = _medicalRecord.Images;
            _context.MedicalRecords.Update(medicalRecord);
            _context.SaveChanges();
        }

        public void PostMedicalRecord(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
        }

        public void DeleteMedicalRecord(int id)
        {
            var anamnesis = _context.MedicalRecords.Find(id);
            if (anamnesis != null)
            {
                _context.MedicalRecords.Remove(anamnesis);
            }
            _context.SaveChanges();
        }
    }
}

