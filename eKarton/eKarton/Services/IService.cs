using System.Collections.Generic;

namespace eKarton.Services
{ 
    public interface IService<T>
    {
        public List<T> GetAll();
        public T GetByGuid(string guid);
        public List<T> GetByCondition(T entity);
        public void Create(T obj);
        public void Update(string guid, T obj);
        public void Delete(string guid);
    }
}
