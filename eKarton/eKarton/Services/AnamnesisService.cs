using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class AnamnesisService
    {
        private readonly MedicalRecordContext _context;
        public AnamnesisService(MedicalRecordContext context)
        {
            _context = context;
        }

        public List<Anamnesis> GetAnamnesies()
        {
            return _context.Anamnesis.ToList();
        }

        public Anamnesis GetAnamnesis(int id)
        {
            return _context.Anamnesis.Find(id);
        }

        public void PutAnamnesis(int id, Anamnesis _anamnesis)
        {
            Anamnesis anamnesis = _context.Anamnesis.Find(id);
            anamnesis.Id = _anamnesis.Id;
            anamnesis.Diseases = _anamnesis.Diseases;
            anamnesis.SocioEpidemiologicalStatus = _anamnesis.SocioEpidemiologicalStatus;
            _context.Anamnesis.Update(anamnesis);
            _context.SaveChanges();
        }

        public void PostAnamnesis(Anamnesis anamnesis)
        {
            _context.Anamnesis.Add(anamnesis);
            _context.SaveChanges();
        }

        public void DeleteAnamnesis(int id)
        {
            var anamnesis = _context.Anamnesis.Find(id);
            if (anamnesis != null)
            {
                _context.Anamnesis.Remove(anamnesis);
            }
            _context.SaveChanges();
        }
    }
}
