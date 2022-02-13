namespace Pessoa.Shared.ContractsCommand{ 
    public class GenericCommandResult : ICommandResult{  

        public GenericCommandResult(bool success,string message,object data){ 
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericCommandResult(){

        }
        
        public bool Success { get; set; }
        public object Data{get; set;}
        public string Message { get; set; }
    } 
}