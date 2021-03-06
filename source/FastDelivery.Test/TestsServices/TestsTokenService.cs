using FastDelivery.Domain.Entities;
using FastDelivery.Services.InternalServices;
using FastDelivery.Shared.Configurations;
using Xunit;

namespace FastDelivery.Shared.TestsServices{ 
    public class TestsTokenService { 

        private readonly TokenService tokenService = new TokenService( new TokenConfiguration("2121554","544514","dfoksdpofjk345854541"));
        public TestsTokenService()
        {
            
        }

        [Fact]
        public void Deve_gerar_um_token_corretamente()
        {
            var token = tokenService.GenerateToken(new UserEntity("userName","user","password","user"));
            Assert.NotNull(token);
        }
    }
}