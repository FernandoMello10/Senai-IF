using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaiChamados.Interfaces;
using SenaiChamados.Models;
using SenaiChamados.Repositories;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SenaiChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _repo = usuarioRepository;
        }

        //POST api/Login
        /// <summary>
        /// Autentica um usuário através de email e senha.
        /// </summary>
        /// <param name="loginModel">Input para o login contendo email e senha do usuário</param>
        /// <returns>Token de autorização JWT - StatusCode 200</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            var usuarioLogado = _repo.BuscarEmailSenha(loginModel.Email, loginModel.Senha);

            if (usuarioLogado == null)
            {
                return StatusCode(401, "Email e/ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.Id.ToString()),
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
