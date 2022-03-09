using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Queries;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Context;

namespace Pessoa.Infra.Repository{

    public class UserRepository : Repository<UserEntity>,IUserEntityRepository
    {
        private readonly PessoaContext _pessoaContext;
        public UserRepository(PessoaContext pessoaContext): base(pessoaContext)
        {
            _pessoaContext = pessoaContext;
        }

        public async Task<UserEntity> VerifyAuthLogin(string login,string password)
        {
          return await _pessoaContext.Users.FirstOrDefaultAsync(UsersQueries.GetByLoginAndPassoword(login,password));
        }
    }
}