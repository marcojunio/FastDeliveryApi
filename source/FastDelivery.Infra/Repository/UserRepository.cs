using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Queries;
using FastDelivery.Domain.Repositories;
using FastDelivery.Infra.Context;

namespace FastDelivery.Infra.Repository{

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