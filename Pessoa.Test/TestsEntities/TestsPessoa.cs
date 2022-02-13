using Pessoa.Domain.Entities;
using Pessoa.Domain.ValueObjects;
using Xunit;

namespace Pessoa.Test.TestsEntities{ 
    public class TestPessoa{ 
        
        private readonly PessoaEntity pessoa = new PessoaEntity("Marcos","André",new DocumentoVo("12345678912"),22,new EmailVo("marco_jr2010@hotmail.com"));
        
        [Fact]
        public void Deve_garantir_que_o_email_nao_troque_caso_seja_invalido(){
            pessoa.MudarEmail(new EmailVo("testando_invalido@gmail"));
            Assert.Equal("marco_jr2010@hotmail.com",pessoa.Email.Endereco);
        }

         [Fact]
        public void Deve_garantir_que_o_email__troque_caso_seja_valido(){
            pessoa.MudarEmail(new EmailVo("testando_invalido@gmail.com"));
            Assert.Equal("testando_invalido@gmail.com",pessoa.Email.Endereco);
        }
    }
}