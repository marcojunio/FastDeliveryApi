using System;
using System.Linq.Expressions;
using FastDelivery.Domain.Entities;

namespace FastDelivery.Domain.Queries{ 
    public static class PessoaQueries { 

        public static Expression<Func<PessoaEntity,bool>> GetById(string id){
            return x => x.Id == id;
        }
    }
}