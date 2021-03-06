using Microsoft.IdentityModel.Tokens;
using SenaiChamados.Helpers;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Domain;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SenaiChamados.Models.Enums;
using System.Text.RegularExpressions;
using SenaiChamados.Models;

namespace SenaiChamados.Application
{
    public class UsuarioApplication : GenericApplication<UsuarioModel, UsuarioDTO>, IUsuarioApplication
    {
        private IUsuarioRepository _repo { get; set; }
        public UsuarioApplication(IUsuarioRepository repository) : base(repository) { _repo = repository;  }

        #region Cadastrar
        public void Cadastrar(CadastroViewModel cadastroModel)
        {
            ValidarModeloNovo(cadastroModel, out var telefoneApenasNumeros);

            var dto = new UsuarioDTO
            {
                IdTipoUsuario = (int)TipoUsuario.Funcionário,
                IdSetor = cadastroModel.SetorID,
                Nome = cadastroModel.Nome,
                Email = cadastroModel.Email,
                Senha = CryptographyHelper.ToMD5(cadastroModel.Senha),
                Telefone = FormatarTelefone(telefoneApenasNumeros)
            };

            _repo.Salvar(dto);
        }

        private void ValidarModeloNovo(CadastroViewModel cadastroModel, out string telefoneApenasNumeros)
        {
            telefoneApenasNumeros = new Regex("[^a-zA-Z0-9 -]").Replace(cadastroModel.Telefone, "");

            if (telefoneApenasNumeros.Length != 10 && telefoneApenasNumeros.Length != 11)
                throw new ArgumentException("Telefone inválido");

            var usuario = _repo.BuscarPorEmail(cadastroModel.Email);

            if (usuario != null)
                throw new ArgumentException("Email já cadastrado");
        }

        private static string FormatarTelefone(string telefoneApenasNumeros)
        {
            var ddd = telefoneApenasNumeros.Substring(0, 2);

            bool ehCelular = telefoneApenasNumeros.Length == 11;

            var tamanhoPrimeiraParte = ehCelular ? 5 : 4;
            string primeiraSequenciaTel = telefoneApenasNumeros.Substring(2, tamanhoPrimeiraParte);

            var indiceComecoSegundaParte = ehCelular ? 7 : 6;
            string segundaSequenciaTel = telefoneApenasNumeros.Substring(indiceComecoSegundaParte, 4);

            return $"({ddd}) {primeiraSequenciaTel}-{segundaSequenciaTel}";
        }
        #endregion Cadastrar

        #region Login
        public TokenViewModel Login(LoginViewModel loginModel)
        {
            var usuarioLogado = _repo.BuscarEmailSenha(loginModel.Email, CryptographyHelper.ToMD5(loginModel.Senha));

            if (usuarioLogado == null)
                return null;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioLogado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioLogado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioLogado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("chave-autenticacao-senaichamados"));

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
        #endregion Login

        #region BuildModel

        protected override UsuarioModel BuildModel(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }
        #endregion BuildModel
    }
}
