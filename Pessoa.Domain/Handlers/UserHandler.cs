using System.Collections.Generic;
using System.Threading.Tasks;
using Pessoa.Domain.Commands;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Repositories;
using Pessoa.Domain.Services;
using Pessoa.Domain.Validators;
using Pessoa.Shared.ContractsCommand;
using Pessoa.Shared.ContractsHandle;

namespace Pessoa.Domain.Handlers{
    public class UserHandler : IHandle<CommandCreateUser> , IHandle<CommandLoginUser>
    {
        private readonly IUserEntityRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserHandler(IUserEntityRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> Handle(CommandCreateUser command)
        {
            var validator = new UserValidator()
            .LoginIsValid(command.Login)
            .LoginHaveLength(command.Login,5);

            if(!validator.isValid())
                return new GenericCommandResult{
                    Data = null,
                    Success = false,
                    Messages = validator.Errors
                };
            
            
            var user = new UserEntity(command.Login,command.Password,"User");
           
           await _userRepository.Save(user);

            return new GenericCommandResult{ 
                Success = true,
                Messages = new List<string>
                {
                    "Cadastro feito com sucesso."
                },
                Data = new { 
                    Id = user.Id,
                    Nome = user.Nome
                } 
            };
        }

        public Task<ICommandResult> Handle(CommandLoginUser command)
        {
            throw new System.NotImplementedException();
        }
    }
}