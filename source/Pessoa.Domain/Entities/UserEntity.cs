using System;
using Pessoa.Shared.ContractsEntities;

namespace Pessoa.Domain.Entities{ 
    public class UserEntity:Entity { 

        public UserEntity(string name,string login,string password,string role)
        {
            Name = name;
            Role = role;
            Login = login;
            Password = password;
            Salt = Guid.NewGuid().ToString();    
        }

        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Role { get;private set;}
    }
}