
using FastDelivery.Shared.ContractsValidators;

namespace FastDelivery.Domain.Validators{ 
    public class UserValidator : Validator{

        public UserValidator()
        {
        }

        public UserValidator LoginIsValid(string login,string mensagem){
            
            if(string.IsNullOrEmpty(login))
                Errors.Add(mensagem);

            return this;
        }


         public UserValidator PasswordIsValid(string password,string mensagem){
            
            if(string.IsNullOrEmpty(password))
                Errors.Add(mensagem);

            return this;
        }

        
        public UserValidator LoginHaveLength(string login,int length){
            
            if(login.Length < length)
                Errors.Add($"Login deve ter no mínimo {length} caracteres.");

            return this;
        }

    }
} 