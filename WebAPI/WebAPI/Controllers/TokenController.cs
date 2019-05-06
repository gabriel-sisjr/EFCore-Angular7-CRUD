using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            if(request.Login == "teste" && request.Senha == "123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Login)
                    // new Claim(ClaimTypes.Role, "ADM") // Caso utilize niveis de acesso.
                };


                // Recebe uma instancia da classe SymmetricSecurityKey e armazena a key de segurança settada no appsettings.
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                // Recebe uma instancia de SigningCredentials contendo a chave de critpgrafia e o algoritmo q fará a encr/descriptogafia
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                // Criando o token efetivamente
                var token = new JwtSecurityToken(
                    issuer: "Gabriel", // Emissor
                    audience: "Gabriel",
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais Invalidas");
        }
    }
}
