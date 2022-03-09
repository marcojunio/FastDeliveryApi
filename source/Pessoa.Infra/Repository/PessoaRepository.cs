using Pessoa.Domain.Entities;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Context;

namespace Pessoa.Infra.Repository{

    public class PessoaRepository : Repository<PessoaEntity>,IPessoaEntityRepository
    {
        private readonly PessoaContext _pessoaContext;
        
        public PessoaRepository(PessoaContext pessoaContext):
            base(pessoaContext){ 
       }
    }
}