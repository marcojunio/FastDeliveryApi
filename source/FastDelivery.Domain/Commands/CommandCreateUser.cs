using FastDelivery.Shared.ContractsCommand;

namespace FastDelivery.Domain.Commands{
    public class CommandCreateUser : ICommand{ 
        public string Login { get; set; }
        public string Password{get;set;}
        public string Nome { get; set; }
    }
}