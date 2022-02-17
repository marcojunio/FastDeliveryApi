using System;
using System.Linq.Expressions;
using Pessoa.Domain.Entities;

namespace Pessoa.Domain.Queries{ 
    public static class PessoaQueries { 

        public static Expression<Func<PessoaEntity,bool>> GetById(string id){
            return x => x.Id == id;
        }
    }
}