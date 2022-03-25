using FastDelivery.Domain.Entities;
using FastDelivery.Shared.ContractsEntities;

namespace FastDelivery.Domain.Services{
    public interface ITokenService{ 
        string GenerateToken(UserEntity entity);
    }
}