using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FastDelivery.Domain.Queries;
using FastDelivery.Infra.Context;
using FastDelivery.Shared.ContractsEntities;
using FastDelivery.Shared.ContractsRepository;

namespace FastDelivery.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly PessoaContext _pessoaContext;

        private DbSet<T> _dataSet;

        public Repository(PessoaContext pessoaContext)
        {
            _pessoaContext = pessoaContext;
            _dataSet = _pessoaContext.Set<T>();
        }


        public async Task Delete(string id)
        {
            var obj = await GetById(id);

            if (obj != null)
            {
                _dataSet.Remove(obj);
                await _pessoaContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dataSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return (T)await _dataSet.FirstOrDefaultAsync(GenericQueries.GetById(id));
        }

        public async Task Save(T obj)
        {
            await _dataSet.AddAsync(obj);
            await _pessoaContext.SaveChangesAsync();
        }

        public async Task Update(T obj)
        {
            _pessoaContext.Entry(obj).CurrentValues.SetValues(obj);
            await _pessoaContext.SaveChangesAsync();
        }
    }
}