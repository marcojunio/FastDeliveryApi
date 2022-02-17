using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{

    public class CommandUpdatePessoa:ICommand{ 

        public CommandUpdatePessoa()
        {
            
        }

        public CommandUpdatePessoa(string id,string email)
        {
            Id = id;
            Email = email;
        }

        public string Id { get; set; }
        public string Email { get; set; }
    }
}