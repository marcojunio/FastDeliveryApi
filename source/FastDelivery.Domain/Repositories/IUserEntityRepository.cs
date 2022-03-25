using System.Threading.Tasks;
using FastDelivery.Domain.Entities;
using FastDelivery.Shared.ContractsRepository;

namespace FastDelivery.Domain.Repositories{ 
    public interface IUserEntityRepository : IRepository<UserEntity> {
        Task<UserEntity> VerifyAuthLogin(string login,string passoword);

    }
}