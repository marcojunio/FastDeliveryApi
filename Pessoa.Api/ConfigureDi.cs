using Microsoft.Extensions.DependencyInjection;
using Pessoa.Domain.Handlers;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Repository;

namespace Pessoa.Api
{
    public static class ConfigureDi
    {
        public static void Inject(IServiceCollection service)
        {
            service.AddTransient<IPessoaEntityRepository,PessoaRepository>();
            service.AddTransient<PessoaHandler,PessoaHandler>();
        }
    }
}