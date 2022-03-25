using FastDelivery.Shared.ContractsCommand;

namespace FastDelivery.Domain.Commands{

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