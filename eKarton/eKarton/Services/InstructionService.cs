using eKarton.Models.SQL;
using System.Collections.Generic;
using System.Linq;

namespace eKarton.Services
{
    public class InstructionService : IService<Instruction>
    {
        private readonly MedicalRecordContext _context;
        public InstructionService(MedicalRecordContext context)
        {
            _context = context;
        }
        public List<Instruction> GetAll()
        {
            return _context.Instructions.ToList();
        }

        public Instruction GetByGuid(string guid)
        {
            return _context.Instructions.Find(guid);
        }
        public void Create(Instruction obj)
        {
            obj.ImageType = ImageType.INSTRUCTION;
            _context.Instructions.Add(obj);
            _context.SaveChanges();
        }

        public void Update(string guid, Instruction obj, Instruction objToUpdate)
        {
            objToUpdate.ImagePath = obj.ImagePath;
            objToUpdate.SpecializationTo = obj.SpecializationTo;
            _context.Instructions.Update(objToUpdate);
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
                _context.Instructions.Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
    
