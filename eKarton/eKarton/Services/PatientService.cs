using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class PatientService
    {
        private readonly MedicalRecordContext _context;
        public PatientService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Patient> GetPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients.Find(id);
        }

        public void PutPatient(int id, Patient _patient)
        {
            Patient patient = _context.Patients.Find(id);
            patient.FirstName = patient.FirstName;
            patient.LastName = patient.LastName;
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
            _context.SaveChanges();
        }
    }
}
