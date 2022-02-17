using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{
    public class CommandCreateUser : ICommand{ 
        public string Login { get; set; }
        public string Password{get;set;}
        public string Nome { get; set; }
    }
}