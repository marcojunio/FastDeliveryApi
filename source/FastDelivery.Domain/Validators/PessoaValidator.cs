using FastDelivery.Domain.ValueObjects;
using FastDelivery.Shared.ContractsValidators;

namespace FastDelivery.Domain.Validators{ 
    public class PessoaValidator : Validator{ 


        public PessoaValidator(){

        }
        
        public PessoaValidator NameIsValid(string nome){
            
            if(string.IsNullOrEmpty(nome))
                Errors.Add("Nome obrigatório.");

            return this;
        }

        public PessoaValidator SobrenomeIsValid(string sobrenome){
            
            if(string.IsNullOrEmpty(sobrenome))
                Errors.Add("Sobrenome obrigatório.");

            return this;
        }

        public PessoaValidator EmailIsValid(string email){ 
            var obj = new EmailVo(email);

            if(!obj.isValid())
                Errors.Add("E-mail inválido.");
            
            return this;
        }
    }
}