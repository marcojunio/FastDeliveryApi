
using Pessoa.Shared.ContractsValidators;

namespace Pessoa.Domain.Validators{ 
    public class UserValidator : Validator{

        public UserValidator()
        {
        }

        public UserValidator LoginIsValid(string login){
            
            if(string.IsNullOrEmpty(login))
                Errors.Add("Login obrigatório.");

            return this;
        }

        
        public UserValidator LoginHaveLength(string login,int length){
            
            if(login.Length < length)
                Errors.Add($"Login deve ter no mínimo {length} caracteres.");

            return this;
        }

    }
} 