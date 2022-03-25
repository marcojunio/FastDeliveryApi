using System.Collections.Generic;

namespace FastDelivery.Shared.ContractsValidators{
    public abstract class Validator{ 
        public List<string> Errors = new List<string>();
        public bool isValid() => Errors.Count == 0;
    }
}