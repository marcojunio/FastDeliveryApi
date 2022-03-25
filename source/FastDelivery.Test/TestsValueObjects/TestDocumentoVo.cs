using FastDelivery.Domain.Enum;
using FastDelivery.Domain.ValueObjects;
using Xunit;

namespace FastDelivery.Test.TestsValueObjects
{
    public class TestDocumentoVo
    {

        public readonly DocumentoVo cpnj = new DocumentoVo("12345678912345");
        public readonly DocumentoVo cpf = new DocumentoVo("12345678912");

        [Fact]
        public void Deve_Validar_Documento_Cnpj(){
            Assert.Equal(ETipoDocumento.CNPJ,cpnj.TipoDocumento);
        }   

          [Fact]
        public void Deve_Validar_Documento_CPF(){
            Assert.Equal(ETipoDocumento.CPF,cpf.TipoDocumento);
        }   
    }
}