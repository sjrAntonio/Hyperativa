using Hyperativa_Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AspCore_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SegurancaController : ControllerBase
    {
        private IConfiguration _config;
        private const int iExpiracao = 10;

        public SegurancaController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost]
        public IActionResult Login([FromBody]Hyperativa_BancoDados.Usuario loginDetalhes)
        {
            bool resultado = validarUsuario.ValidarUsuario(loginDetalhes);

            if (resultado)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GerarTokenJWT()
        {
            string issuer    = _config["Jwt:Issuer"];
            string audience  = _config["Jwt:Audience"];

            DateTime dt_Expiry  = DateTime.Now.AddMinutes(iExpiracao);

            var securityKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials  = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token        = new JwtSecurityToken(issuer: issuer, audience: audience, expires: dt_Expiry, signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();

            string sToken    = tokenHandler.WriteToken(token);

            return sToken;
        }
    }
}