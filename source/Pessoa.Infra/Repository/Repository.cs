using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Queries;
using Pessoa.Infra.Context;
using Pessoa.Shared.ContractsEntities;
using Pessoa.Shared.ContractsRepository;

namespace Pessoa.Infra.Repository{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        private readonly PessoaContext _pessoaContext;

        private DbSet<T> _dataSet;
        
        public Repository(PessoaContext pessoaContext){ 
            _pessoaContext = pessoaContext;
            _dataSet = _pessoaContext.Set<T>();
        }


        public async Task Delete(string id)
        {
            var obj = await GetById(id);

            if(obj != null)
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
           return (T) await _dataSet.FirstOrDefaultAsync(GenericQueries.GetById(id));
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