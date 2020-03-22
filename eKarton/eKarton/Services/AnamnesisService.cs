using eKarton.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class AnamnesisService : IService<Anamnesis>
    {
        private readonly MedicalRecordContext _context;

        public AnamnesisService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Anamnesis> GetAll()
        {
            return _context.Anamnesis.Include(x => x.Diseases).ToList();
        }

        public Anamnesis GetByGuid(string guid)
        {
            return _context.Anamnesis.Include(x => x.Diseases).SingleOrDefault(x => x.Guid.Equals(guid));
        }

        public List<Anamnesis> GetByCondition(Anamnesis anamnesis)
        {
            throw new NotImplementedException();
        }

        public void Create(Anamnesis obj)
        {
            _context.Anamnesis.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Anamnesis obj)
        {
            Anamnesis anamnesis = _context.Anamnesis.Include(x => x.Diseases).SingleOrDefault(x => x.Guid.Equals(guid));
            foreach (Disease disease in obj.Diseases)
            {
                if (_context.Medicines.Find(disease.Guid) != null)
                {
                    _context.Diseases.Update(disease);
                }
                else
                {
                    _context.Diseases.Add(disease);
                }
                anamnesis.Diseases.Add(disease);
            }
            anamnesis.SocioEpidemiologicalStatus = obj.SocioEpidemiologicalStatus; 
            _context.Anamnesis.Update(anamnesis);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var anamnesis = _context.Anamnesis.Find(guid);
            if (anamnesis != null)
            {
                _context.Anamnesis.Remove(anamnesis);
                _context.SaveChanges();
            }
        }
    }
}
