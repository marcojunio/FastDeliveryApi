using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{
 
    public class CommandCreatePessoa : ICommand{ 
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Idade { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}