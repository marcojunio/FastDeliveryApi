using Pessoa.Domain.Entities;
using Pessoa.Shared.ContractsEntities;

namespace Pessoa.Domain.Services{
    public interface ITokenService{ 
        string GenerateToken(UserEntity entity);
    }
}