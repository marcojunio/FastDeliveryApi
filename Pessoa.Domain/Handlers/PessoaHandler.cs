using System.Collections.Generic;
using System.Threading.Tasks;
using Pessoa.Domain.Commands;
using Pessoa.Domain.Entities;
using Pessoa.Domain.Repositories;
using Pessoa.Domain.Validators;
using Pessoa.Domain.ValueObjects;
using Pessoa.Shared.ContractsCommand;
using Pessoa.Shared.ContractsHandle;

namespace Pessoa.Domain.Handlers{
    public class PessoaHandler : IHandle<CommandCreatePessoa>,IHandle<CommandUpdatePessoa>
    {
        private readonly IPessoaEntityRepository _pessoaEntityRepository;

        public PessoaHandler(IPessoaEntityRepository pessoaEntityRepository){
            _pessoaEntityRepository = pessoaEntityRepository;
        }

        public async Task<ICommandResult> Handle(CommandCreatePessoa command)
        {

            var valid = new PessoaValidator()
                .EmailIsValid(command.Email)
                .NameIsValid(command.Nome)
                .SobrenomeIsValid(command.Sobrenome);

            if(!valid.isValid())
                return new GenericCommandResult{ 
                    Data = valid.Errors,
                    Success = false,
                    Message = "Bad request"
                };

            var pessoa = new PessoaEntity(command.Nome,command.Sobrenome,new DocumentoVo(command.Documento),command.Idade,new EmailVo(command.Email));

            await _pessoaEntityRepository.Save(pessoa);

            return new GenericCommandResult{ 
                Success = true,
                Message = "Request success",
                Data = pessoa 
            };
        }

        public async Task<ICommandResult> Handle(CommandUpdatePessoa command)
        {
             var valid = new PessoaValidator()
                .EmailIsValid(command.Email);

            if(!valid.isValid())
                return new GenericCommandResult{ 
                    Data = valid.Errors,
                    Success = false,
                    Message = "Bad request"
                };

            var pessoa = await _pessoaEntityRepository.GetById(command.Id);
            pessoa.MudarEmail(new EmailVo(command.Email));

            await _pessoaEntityRepository.Update(pessoa);

            return new GenericCommandResult{ 
                Success = true,
                Message = "Request success",
                Data = pessoa 
            };
        }
    }
}