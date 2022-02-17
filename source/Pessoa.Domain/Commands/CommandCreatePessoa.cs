using Pessoa.Shared.ContractsCommand;

namespace Pessoa.Domain.Commands{
 
    public class CommandCreatePessoa : ICommand{ 

        public CommandCreatePessoa()
        {
            
        }

        public CommandCreatePessoa(string nome,string documento,int idade,string sobrenome,string email)
        {
            Nome = nome;
            Documento = documento;
            Idade = idade;
            Sobrenome = sobrenome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Idade { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}