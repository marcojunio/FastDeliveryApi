using System.Collections.Generic;
using System.Threading.Tasks;
using FastDelivery.Shared.ContractsEntities;

namespace FastDelivery.Shared.ContractsRepository{ 
    public interface IRepository<T> where T : Entity { 

        public Task Save (T obj); 
        public Task Update(T obj);
        public Task<T> GetById(string id);
        public Task<ICollection<T>> GetAll();
        public Task Delete(string id);
    }
}