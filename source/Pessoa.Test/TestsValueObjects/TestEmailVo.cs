using Pessoa.Domain.ValueObjects;
using Xunit;

namespace Pessoa.Test.TestsValueObjects{ 
    public class TestEmailVo{ 

        private readonly EmailVo emailValid = new EmailVo("teste_validade@hotmail.com");
        private readonly EmailVo emailInvalid = new EmailVo("teste_validade@hotmail");
        
        [Fact]
        public void Deve_garantir_que_o_email_seja_valido(){
            Assert.True(emailValid.isValid());
        }


         [Fact]
        public void Deve_garantir_que_o_email_seja_invalido(){
            Assert.False(emailInvalid.isValid());
        }
    }
}