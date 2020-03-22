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

        public List<Patient> GetByCondition(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void Create(Patient obj)
        {
            if (obj.Guid != null)
            {
                obj.Guid = Guid.NewGuid().ToString();
            }
            obj.CreatedAt = DateTime.Now;
            _context.Patients.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Patient obj)
        {   
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