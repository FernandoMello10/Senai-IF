using Microsoft.IdentityModel.Tokens;
using SenaiChamados.Helpers;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Models;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SenaiChamados.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioApplication(IUsuarioRepository UsuarioRepository)
        {
            _repo = UsuarioRepository;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _repo.GetAll();
        }

        public Usuario GetByID(int id)
        {
            return _repo.GetByID(id);
        }

        public TokenViewModel Login(LoginViewModel loginModel)
        {
            var usuarioLogado = _repo.BuscarEmailSenha(loginModel.Email, CryptographyHelper.CreateMD5(loginModel.Senha));

            if (usuarioLogado == null)
                return null;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioLogado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioLogado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SenaiChamados"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new TokenViewModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public void Save(Usuario newModel)
        {
            newModel.Senha = CryptographyHelper.CreateMD5(newModel.Senha);

            _repo.Save(newModel);
        }

        public void Update(Usuario updatedModel)
        {
            _repo.Update(updatedModel);
        }
    }
}
