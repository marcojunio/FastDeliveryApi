using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Repositories;
using FastDelivery.Infra.Context;

namespace FastDelivery.Infra.Repository{

    public class PessoaRepository : Repository<PessoaEntity>,IPessoaEntityRepository
    {
        public PessoaRepository(PessoaContext pessoaContext):
            base(pessoaContext){ 
       }
    }
}