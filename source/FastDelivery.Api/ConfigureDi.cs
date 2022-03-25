using Microsoft.Extensions.DependencyInjection;
using FastDelivery.Domain.Handlers;
using FastDelivery.Domain.Repositories;
using FastDelivery.Domain.Services;
using FastDelivery.Infra.Repository;
using FastDelivery.Services.InternalServices;
using FastDelivery.Shared.Core.FileManipulation.Contracts;
using FastDelivery.Shared.Core.FileManipulation.Implementations;
using FastDelivery.Shared.Core.FileManipulation.Implementations.Upload;

namespace FastDelivery.Api
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