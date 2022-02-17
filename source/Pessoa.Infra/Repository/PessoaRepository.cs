using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Queries;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pessoa.Infra.Repository{

    public class PessoaRepository : IPessoaEntityRepository
    {
        private readonly PessoaContext _pessoaContext;
        
        public PessoaRepository(PessoaContext pessoaContext){ 
            _pessoaContext = pessoaContext;
        }

        public async Task Delete(string id)
        {
            var obj = await GetById(id);

            if(obj != null)
            {
                _pessoaContext.Pessoas.Remove(obj);
                await _pessoaContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<PessoaEntity>> GetAll()
        {
           return await _pessoaContext.Pessoas
           .AsNoTracking()
           .ToListAsync();
        }

        public async Task<PessoaEntity> GetById(string id)
        {
            return await _pessoaContext.Pessoas.FirstOrDefaultAsync(PessoaQueries.GetById(id));
        }

        public async Task Save(PessoaEntity obj)
        {
            await _pessoaContext.Pessoas.AddAsync(obj);
            await _pessoaContext.SaveChangesAsync();
        }

        public async Task Update(PessoaEntity obj)
        {
            _pessoaContext.Entry(obj).State = EntityState.Modified;
            _pessoaContext.Update(obj);
            await _pessoaContext.SaveChangesAsync();
        }
    }
}