using System.Collections.Generic;
using System.Threading.Tasks;
using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Repositories;

namespace FastDelivery.Test.FakeRepositories{
    public class FakePessoaRepository : IPessoaEntityRepository
    {
        public Task Delete(string id)
        {
            return Task.Delay(10);
        }

        public Task<ICollection<PessoaEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<PessoaEntity> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(PessoaEntity obj)
        {
            return Task.Delay(10);
        }

        public Task Update(PessoaEntity obj)
        {
            return Task.Delay(10);
        }
    }
}