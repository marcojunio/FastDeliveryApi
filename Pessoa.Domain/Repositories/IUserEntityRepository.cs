using System.Threading.Tasks;
using Pessoa.Domain.Entities;
using Pessoa.Shared.ContractsRepository;

namespace Pessoa.Domain.Repositories{ 
    public interface IUserEntityRepository : IRepository<UserEntity> {
        Task<UserEntity> VerifyAuthLogin(string login,string passoword);

    }
}