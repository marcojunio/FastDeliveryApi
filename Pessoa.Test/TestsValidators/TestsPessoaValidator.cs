using Pessoa.Domain.Validators;
using Xunit;

namespace Pessoa.Test.TestsValidator
{
    public class TestsPessoaValidator
    {
        private readonly PessoaValidator pessoaValid = new PessoaValidator()
            .NameIsValid("teste")
            .SobrenomeIsValid("teste2")
            .EmailIsValid("test3@gmail.com");

        private readonly PessoaValidator pessoaInvalid = new PessoaValidator()
            .NameIsValid("")
            .SobrenomeIsValid("")
            .EmailIsValid("test3@gmail");

        [Fact]
        public void Deve_garantir_pessoa_valida()
        {
            Assert.True(pessoaValid.isValid());
        }

        [Fact]
        public void Deve_garantir_pessoa_invalida()
        {
            Assert.False(pessoaInvalid.isValid());
        }
    }
}
