using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaiChamados.Interfaces;
using SenaiChamados.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            Usuario usuarioLogado = _usuarioRepository.BuscarEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioLogado == null)
            {
                return StatusCode(400, "email ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioLogado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioLogado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SenaiChamados"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
