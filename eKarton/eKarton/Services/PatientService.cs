using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eKarton.Services
{
    public class PatientService : IService<Patient>
    {
        private readonly MedicalRecordContext _context;
        public PatientService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetByGuid(string guid)
        {
            return _context.Patients.Find(guid);
        }

        public void Create(Patient obj)
        {
            _context.Patients.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Patient obj, Patient objToUpdate)
        {
            objToUpdate.DateOfBirth = obj.DateOfBirth;
            objToUpdate.EMail = obj.EMail;
            objToUpdate.FathersName = obj.FathersName;
            objToUpdate.FirstName = obj.FirstName;
            objToUpdate.Gender = obj.Gender;
            objToUpdate.HealthInsuranceNumber = obj.HealthInsuranceNumber;
            objToUpdate.LastName = obj.LastName;
            objToUpdate.MothersName = obj.MothersName;
            objToUpdate.TypeOfInsurance = obj.TypeOfInsurance;
            objToUpdate.UniqueCitizensIdentityNumber = obj.UniqueCitizensIdentityNumber;
            _context.Patients.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var patient = _context.Patients.Find(guid);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
            _context.SaveChanges();
        }
    }
}