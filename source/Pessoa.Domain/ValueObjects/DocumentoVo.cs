using Pessoa.Shared.ContractsValueObjects;
using Pessoa.Domain.Enum;

namespace Pessoa.Domain.ValueObjects{ 

    public class DocumentoVo : IValueObjects{ 

        public DocumentoVo(string documento)
        {
            Documento = documento;
            DefinirDocumento();
        }

        public DocumentoVo()
        {
          
        }

        public ETipoDocumento TipoDocumento { get;private set;}
        public string Documento { get; private set; }

        public void DefinirDocumento(){
            if(Documento.Length == 11)
                TipoDocumento = ETipoDocumento.CPF;

            if(Documento.Length == 14)
                TipoDocumento = ETipoDocumento.CNPJ;
        }
    }   
}