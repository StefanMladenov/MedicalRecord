using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class LekarServis
    {
        private readonly EKartonContext _context;
        public LekarServis(EKartonContext context)
        {
            _context = context;
        }

        public List<Lekar> GetLekari()
        {
            return _context.Lekari.ToList();
        }

        public Lekar GetLekar(int id)
        {
            return _context.Lekari.Find(id);
        }

        public void PutLekar(int id, Lekar lekar)
        {
            Lekar _lekar = _context.Lekari.Find(id);
            _lekar.Ime = lekar.Ime;
            _lekar.Prezime = lekar.Prezime;
            _context.Lekari.Update(_lekar);
            _context.SaveChanges();
        }      
        
        public void PostLekar(Lekar lekar)
        {
            //Lekar _lekar = _context.Lekari.Find(id);
            //_lekar.Ime = lekar.Ime;
            //_lekar.Prezime = lekar.Prezime;
            _context.Lekari.Add(lekar);
            _context.SaveChanges();
        }
    }
}
