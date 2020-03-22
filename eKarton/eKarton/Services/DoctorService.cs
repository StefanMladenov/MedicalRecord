using eKarton.Models.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace eKarton.Services
{
    public class DoctorService : IService<Doctor>
    {
        private readonly MedicalRecordContext _context;
        public DoctorService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetByGuid(string guid)
        {
            return _context.Doctors.Find(guid);
        }

        public List<Doctor> GetByCondition(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Create(Doctor obj)
        {
            _context.Doctors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Doctor obj)
        {
            Doctor doctor = _context.Doctors.Find(guid);
            doctor.FirstName = obj.FirstName;
            doctor.LastName = obj.LastName;
            doctor.EMail = obj.EMail;
            doctor.Specialization = obj.Specialization;
            doctor.DateOfBirth = obj.DateOfBirth;
            if(_context.Institutes.Find(obj.Institute.Guid) != null)
            {
                _context.Institutes.Update(obj.Institute);
            }
            else
            {
                _context.Institutes.Add(obj.Institute);
            }
            doctor.Institute = obj.Institute;
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var doctor = _context.Doctors.Find(guid);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
    }
}
