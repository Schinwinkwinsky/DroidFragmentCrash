using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DroidFragmentCrash.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/accounts/signin
        [HttpGet("signin")]
        public IActionResult GetToken()
        {
            return Ok(GetAuthToken());
        }

        private dynamic GetAuthToken()
        {
            var token = new JwtSecurityToken
                (
                    issuer: _configuration.GetSection("AuthSettings:AppName").Value,
                    audience: _configuration.GetSection("AuthSettings:AppName").Value,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthSettings:Key").Value)), SecurityAlgorithms.HmacSha256)
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires = token.ValidTo
            };
        }
    }
}
