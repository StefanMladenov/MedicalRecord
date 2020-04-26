using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class AnalysisService : IService<Analysis>
    {
        private readonly MedicalRecordContext _context;
        public AnalysisService(MedicalRecordContext context)
        {
            _context = context;
        }
        public List<Analysis> GetAll()
        {
            return _context.Analysis.ToList();
        }

        public Analysis GetByGuid(string guid)
        {
            return _context.Analysis.Find(guid);
        }
        public void Create(Analysis obj)
        {
            obj.ImageType = ImageType.ANALYSIS;
            _context.Analysis.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Analysis obj, Analysis objToUpdate)
        {
            objToUpdate.AnalysisType = obj.AnalysisType;
            objToUpdate.ImagePath = obj.ImagePath;
            _context.Analysis.Update(objToUpdate);
            _context.SaveChanges();
        }

        public void Delete(string guid)
        {
            var obj = GetByGuid(guid);
            if (obj != null)
            {
                if (System.IO.File.Exists(obj.ImagePath))
                {
                    System.IO.File.Delete(obj.ImagePath);
                }
                _context.Analysis.Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
