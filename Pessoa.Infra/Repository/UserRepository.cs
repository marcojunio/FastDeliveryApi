using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Queries;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Context;
using Pessoa.Shared.ContractsRepository;

namespace Pessoa.Infra.Repository{

    public class UserRepository : IUserEntityRepository
    {
        private readonly PessoaContext _pessoaContext;
        public UserRepository(PessoaContext pessoaContext)
        {
            _pessoaContext = pessoaContext;
        }

        public async Task Delete(string id)
        {
            var obj = await GetById(id);

            if(obj != null)
            {
                _pessoaContext.Users.Remove(obj);
                await _pessoaContext.SaveChangesAsync();
            }
        }

        public Task<ICollection<UserEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserEntity> GetById(string id)
        {
             return await _pessoaContext.Users.FirstOrDefaultAsync(UsersQueries.GetById(id));
        }

        public async Task Save(UserEntity obj)
        {
            await _pessoaContext.Users.AddAsync(obj);
            await _pessoaContext.SaveChangesAsync();
        }

        public async Task Update(UserEntity obj)
        {
           _pessoaContext.Entry(obj).State = EntityState.Modified;
            _pessoaContext.Update(obj);
            await _pessoaContext.SaveChangesAsync();
        }

        public async Task<UserEntity> VerifyAuthLogin(string login,string password)
        {
          return await _pessoaContext.Users.FirstOrDefaultAsync(UsersQueries.GetByLoginAndPassoword(login,password));
        }
    }
}