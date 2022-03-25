
using FastDelivery.Domain.ValueObjects;
using FastDelivery.Shared.ContractsEntities;

namespace FastDelivery.Domain.Entities{ 
    public class PessoaEntity : Entity { 
        
       public PessoaEntity()
       {

       }
        
      public PessoaEntity(string nome,string sobrenome,DocumentoVo documentoVo,int idade,EmailVo emailVo)
      { 
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documentoVo;
            Idade = idade;
            Email = emailVo;
      }
        public string Nome { get; private set; }
        public string Sobrenome { get;private set; }
        public DocumentoVo Documento { get;private set; }
        public int Idade { get; private set; }
        public EmailVo Email { get;private set; }

        public void MudarNome(string nome) {
            Nome = nome;
        }

        public void MudarEmail(EmailVo emailVo){ 
            if(emailVo.isValid()){
                Email = emailVo;
            }
        }
    }
}