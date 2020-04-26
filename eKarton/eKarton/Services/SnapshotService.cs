using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class SnapshotService : IService<Snapshot>
    {
        private readonly MedicalRecordContext _context;
        public SnapshotService(MedicalRecordContext context)
        {
            _context = context;
        }
        public List<Snapshot> GetAll()
        {
            return _context.Snapshots.ToList();
        }

        public Snapshot GetByGuid(string guid)
        {
            return _context.Snapshots.Find(guid);
        }
        public void Create(Snapshot obj)
        {
            obj.ImageType = ImageType.SNAPSHOT;
            _context.Snapshots.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Snapshot obj, Snapshot objToUpdate)
        {
            objToUpdate.SnapshotType = obj.SnapshotType;
            objToUpdate.ImagePath = obj.ImagePath;
            objToUpdate.BodyPart = obj.BodyPart;
            _context.Snapshots.Update(objToUpdate);
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
                _context.Snapshots.Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
