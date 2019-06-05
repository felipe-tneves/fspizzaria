using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Fspizzaria.Domains;
using Fspizzaria.Interfaces;
using Fspizzaria.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Fspizzaria.Contexts
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario login)
        {
            try
            {
                Usuario usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuario não encontrado, por favor digite novamente" });
                }

                var claims = new[]
                {
                   new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                   new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                   new Claim(ClaimTypes.Role, usuario.Email.ToString()),
              
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Fspizzaria-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "Fspizzaria.WebApi",
                    audience: "Fspizzaria.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro" });

            }
        }
    }
}