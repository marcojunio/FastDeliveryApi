using FastDelivery.Shared.ContractsCommand;

namespace FastDelivery.Domain.Commands{
    public class CommandLoginUser:ICommand{
        public string Login { get; set; }
        public string Password{get;set;}
    }
}