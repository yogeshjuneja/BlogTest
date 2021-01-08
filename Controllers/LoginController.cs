using JWTImplementation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTImplementation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]

    public class LoginController : ControllerBase
    {
        IAuthenticationManager AuthenticationManager;
        public LoginController(IAuthenticationManager objIAuthenticationManager)
        {
            AuthenticationManager = objIAuthenticationManager;
        }
        [HttpPost]
        public IActionResult SignIn(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                string AuthToken = AuthenticationManager.Authenticate(objLoginModel);
                if (!string.IsNullOrEmpty(AuthToken))
                    return Ok(AuthToken);
                else
                    return Unauthorized("Invalid Credentials");
            }
            else
                return BadRequest(ModelState);
        }

    }

}
