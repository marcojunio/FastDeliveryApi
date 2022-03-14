using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

namespace Pessoa.Shared.Helpers{
    public class HttpContextHelper{ 

        public static ResponseClaims GetClaims(IEnumerable<Claim> claims){

            var idCustumer = claims.FirstOrDefault(x => x.Type == "user_id").Value;
            var nameCustumer = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            return new ResponseClaims()
            {
                CustumerId = idCustumer,
                Name = nameCustumer
            };
        }
    }

    public class ResponseClaims{
        public string CustumerId { get; set; }
        public string Name { get; set; }
    };
}