using System.Text.RegularExpressions;
using Pessoa.Shared.ContractsValueObjects;

namespace Pessoa.Domain.ValueObjects{ 
    public class EmailVo : IValueObjects{

        public EmailVo(string email)
        {
            Endereco = email;
        }

        public EmailVo()
        {
        }

        public string Endereco { get; private set; }


        public bool isValid()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(Endereco);
        }
    }
}