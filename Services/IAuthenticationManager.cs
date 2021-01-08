using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTImplementation.Services
{
    public abstract class IAuthenticationManager
    {
        public abstract string Authenticate(LoginModel objLoginModel);
        public virtual string GenerateToken(LoginModel objLoginModel, DateTime Expirytime)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name,objLoginModel.Username)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: Expirytime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thiismysecretkey")), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
