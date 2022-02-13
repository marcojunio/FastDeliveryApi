using System.Threading.Tasks;
using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Shared.ContractsHandle{ 
    public interface IHandle<T> where T : ICommand { 
        Task<ICommandResult> Handle(T command);
    }
}