using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Services
{ 
    interface IService
    {
        public List<T> GetAll<T>();
        public T Get <T>();
        public void Put<T>(int? id,T obj);
        public void Post<T>(T obj);
        public void Delete(int? id);
    }
}
