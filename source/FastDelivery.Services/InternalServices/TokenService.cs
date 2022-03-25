
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FastDelivery.Domain.Entities;
using FastDelivery.Domain.Services;
using FastDelivery.Shared.Configurations;

namespace FastDelivery.Services.InternalServices{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _tokenConfiguration;

        public TokenService(TokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }
        public string GenerateToken(UserEntity entity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenConfiguration.Secret);
        
             var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.Role, entity.Role),
                    new Claim("user_id",entity.Id),
                    new Claim(JwtRegisteredClaimNames.Aud,_tokenConfiguration.Audience),
                    new Claim(JwtRegisteredClaimNames.Iss,_tokenConfiguration.Issuer),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}