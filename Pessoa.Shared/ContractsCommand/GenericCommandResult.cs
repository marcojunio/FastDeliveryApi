using System.Collections.Generic;

namespace Pessoa.Shared.ContractsCommand{ 
    public class GenericCommandResult : ICommandResult{  

        public GenericCommandResult(bool success,ICollection<string> messages,object data,string message){ 
            Success = success;
            Messages = messages;
            Message = message;
            Data = data;
        }

        public GenericCommandResult(){

        }
        
        public bool Success { get; set; }
        public object Data{get; set;}
        public ICollection<string> Messages { get; set; }
        public string Message { get; set; }
    } 
}