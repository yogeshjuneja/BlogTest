using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTImplementation.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        public override string Authenticate(LoginModel objLoginModel)
        {
            if (objLoginModel.Username == objLoginModel.Password && !string.IsNullOrWhiteSpace(objLoginModel.Username))
            {
                var requestAt = DateTime.Now;
                var expiresIn = requestAt.Add(TimeSpan.FromMinutes(30));
                var token = GenerateToken(objLoginModel, expiresIn);
                return JsonConvert.SerializeObject(new
                {
                    requestAt = requestAt,
                    expiresIn = TimeSpan.FromMinutes(30).TotalSeconds,
                    tokeyType = "Bearer",
                    accessToken = token
                });
            }
            else
                return null;
        }
    }
}
