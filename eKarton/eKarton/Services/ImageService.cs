using eKarton.Models.SQL;
using System.Collections.Generic;

namespace eKarton.Services
{
    public class ImageService : IService<Image>
    {
        private readonly MedicalRecordContext _context;

        public ImageService(MedicalRecordContext context)
        {
            _context = context;
        }

        public void Create(Image obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string guid)
        {
            throw new System.NotImplementedException();
        }

        public List<Image> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<Image> GetByCondition(Image entity)
        {
            throw new System.NotImplementedException();
        }

        public Image GetByGuid(string guid)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string guid, Image obj, Image objToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}
