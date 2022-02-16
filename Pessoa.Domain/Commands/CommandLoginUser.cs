using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{
    public class CommandLoginUser:ICommand{
        public string Login { get; set; }
        public string Password{get;set;}
    }
}