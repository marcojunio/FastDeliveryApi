using System;
using System.Linq.Expressions;
using Pessoa.Shared.ContractsEntities;

namespace Pessoa.Domain.Queries{ 
    public class GenericQueries{ 

           public static Expression<Func<Entity,bool>> GetById(string id){
            return x => x.Id == id;
        }
    }
}