using eKarton.Models.SQL;
using Microsoft.EntityFrameworkCore;
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

        public void Create(Anamnesis obj)
        {
            _context.Anamnesis.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Anamnesis obj, Anamnesis objToUpdate)
        {
            foreach (Disease disease in objToUpdate.Diseases)
            {
                _context.Diseases.Remove(disease);
            }
            objToUpdate.Diseases = new List<Disease>();
            if (obj.Diseases != null)
            {
                foreach (Disease dis in obj.Diseases)
                {
                    _context.Diseases.Add(dis);
                    objToUpdate.Diseases.Add(dis);
                }
            }
            objToUpdate.SocioEpidemiologicalStatus = obj.SocioEpidemiologicalStatus;
            _context.Anamnesis.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var anamnesis = GetByGuid(guid);
            if (anamnesis != null)
            {
                if (anamnesis.Diseases != null && anamnesis.Diseases.Count != 0)
                {
                    foreach (Disease dis in anamnesis.Diseases)
                    {
                        _context.Diseases.Remove(dis);
                    }
                }
                _context.Anamnesis.Remove(anamnesis);
                _context.SaveChanges();
            }
        }
    }
}
