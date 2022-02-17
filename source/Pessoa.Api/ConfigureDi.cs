using Microsoft.Extensions.DependencyInjection;
using Pessoa.Domain.Handlers;
using Pessoa.Domain.Repositories;
using Pessoa.Domain.Services;
using Pessoa.Infra.Repository;
using Pessoa.Services.InternalServices;

namespace Pessoa.Api
{
    public static class ConfigureDi
    {
        public static void Inject(IServiceCollection service)
        {

            //Repositories
            service.AddTransient<IPessoaEntityRepository,PessoaRepository>();
            service.AddTransient<IUserEntityRepository,UserRepository>();
            
            //Handlers
            service.AddTransient<PessoaHandler,PessoaHandler>();
            service.AddTransient<UserHandler,UserHandler>();

            //Services
            service.AddTransient<ITokenService,TokenService>();
        }
    }
}