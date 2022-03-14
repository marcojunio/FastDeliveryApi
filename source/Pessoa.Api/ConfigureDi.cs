using Microsoft.Extensions.DependencyInjection;
using Pessoa.Domain.Handlers;
using Pessoa.Domain.Repositories;
using Pessoa.Domain.Services;
using Pessoa.Infra.Repository;
using Pessoa.Services.InternalServices;
using Pessoa.Shared.Core.FileManipulation.Contracts;
using Pessoa.Shared.Core.FileManipulation.Implementations;
using Pessoa.Shared.Core.FileManipulation.Implementations.Upload;

namespace Pessoa.Api
{
    public static class ConfigureDi
    {
        public static void Inject(IServiceCollection service)
        {
            service.AddScoped<IFileService,FileService>();
            service.AddScoped<IUploadFileService,UploadFileService>();
            
            //Repositories
            service.AddScoped<IPessoaEntityRepository,PessoaRepository>();
            service.AddScoped<IUserEntityRepository,UserRepository>();
            
            //Handlers
            service.AddScoped<PessoaHandler,PessoaHandler>();
            service.AddScoped<UserHandler,UserHandler>();

            //Services
            service.AddScoped<ITokenService,TokenService>();
        }
    }
}