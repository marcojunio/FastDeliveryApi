using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{

    public class CommandUpdatePessoa:ICommand{ 
        public string Id { get; set; }
        public string Email { get; set; }
    }
}