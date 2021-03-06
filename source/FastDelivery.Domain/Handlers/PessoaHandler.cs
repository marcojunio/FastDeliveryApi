using System.Collections.Generic;
using System.Threading.Tasks;
using FastDelivery.Domain.Commands;
using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Repositories;
using FastDelivery.Domain.Validators;
using FastDelivery.Domain.ValueObjects;
using FastDelivery.Shared.ContractsCommand;
using FastDelivery.Shared.ContractsHandle;

namespace FastDelivery.Domain.Handlers{
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
                    Data = null,
                    Success = false,
                    Messages = valid.Errors
                };

            var pessoa = new PessoaEntity(command.Nome,command.Sobrenome,new DocumentoVo(command.Documento),command.Idade,new EmailVo(command.Email));

            await _pessoaEntityRepository.Save(pessoa);

            return new GenericCommandResult{ 
                Success = true,
                Messages = new List<string>
                {
                    "Cadastro feito com sucesso."
                },
                Data = pessoa 
            };
        }

        public async Task<ICommandResult> Handle(CommandUpdatePessoa command)
        {
            var pessoa = await _pessoaEntityRepository.GetById(command.Id);

            if(pessoa == null)
                return new GenericCommandResult{ 
                    Data = null,
                    Success = false,
                    Messages = new List<string>
                    {
                        "Nenhuma pessoa encontrada."
                    }
                };

            var valid = new PessoaValidator()
              .EmailIsValid(command.Email);

            if(!valid.isValid())
                return new GenericCommandResult{ 
                    Data = null,
                    Success = false,
                    Messages = valid.Errors
                };

            pessoa.MudarEmail(new EmailVo(command.Email));

            await _pessoaEntityRepository.Update(pessoa);

            return new GenericCommandResult{ 
                Success = true,
                Messages = new List<string> 
                { 
                    "Cadastro alterado com sucesso."
                },
                Data = pessoa 
            };
        }
    }
}