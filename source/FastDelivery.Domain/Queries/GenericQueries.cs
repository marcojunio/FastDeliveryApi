using System;
using System.Linq.Expressions;
using FastDelivery.Shared.ContractsEntities;

namespace FastDelivery.Domain.Queries{ 
    public class GenericQueries{ 

           public static Expression<Func<Entity,bool>> GetById(string id){
            return x => x.Id == id;
        }
    }
}