using Pessoa.Domain.Entities;
using Pessoa.Domain.Repositories;
using Pessoa.Infra.Context;

namespace Pessoa.Infra.Repository{

    public class PessoaRepository : Repository<PessoaEntity>,IPessoaEntityRepository
    {
        public PessoaRepository(PessoaContext pessoaContext):
            base(pessoaContext){ 
       }
    }
}