using System.Threading.Tasks;
using FastDelivery.Shared.ContractsCommand;

namespace FastDelivery.Shared.ContractsHandle{ 
    public interface IHandle<T> where T : ICommand { 
        Task<ICommandResult> Handle(T command);
    }
}