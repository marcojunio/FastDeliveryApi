using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pessoa.Shared.Configurations;

namespace Pessoa.Api{ 
    public static class ConfigureAuth{ 

        public static void Inject(IServiceCollection services,TokenConfiguration token){
            
            var key = Encoding.ASCII.GetBytes(token.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidAudience = token.Audience,
                    ValidIssuer = token.Issuer,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                };
            });
        }
    }
}