using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(Doctor obj)
        {
            _context.Doctors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Doctor obj, Doctor objToUpdate)
        {
            objToUpdate.FirstName = obj.FirstName;
            objToUpdate.LastName = obj.LastName;
            objToUpdate.EMail = obj.EMail;
            objToUpdate.Specialization = obj.Specialization;
            objToUpdate.DateOfBirth = obj.DateOfBirth;
            _context.Doctors.Update(objToUpdate);
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
