using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class DoctorService
    {
        private readonly MedicalRecordContext _context;
        public DoctorService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctor(int id)
        {
            return _context.Doctors.Find(id);
        }

        public void PutDoctor(int id, Doctor doctor)
        {
            Doctor _doctor = _context.Doctors.Find(id);
            _doctor.FirstName = doctor.FirstName;
            _doctor.LastName = doctor.LastName;
            _context.Doctors.Update(_doctor);
            _context.SaveChanges();
        }      
        
        public void PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if(doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            _context.SaveChanges();
        }
    }
}
