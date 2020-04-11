using System.Collections.Generic;

namespace eKarton.Services
{ 
    public interface IService<T>
    {
        public List<T> GetAll();
        public T GetByGuid(string guid);
        public void Create(T obj);
        public void Update(string guid, T obj, T objToUpdate);
        public void Delete(string guid);
    }
}
