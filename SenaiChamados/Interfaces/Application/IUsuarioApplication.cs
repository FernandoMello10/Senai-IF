using SenaiChamados.Domain;
using SenaiChamados.Models;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces.Application
{
    public interface IUsuarioApplication : IGenericApplication<UsuarioModel, UsuarioDTO>
    {
        TokenViewModel Login(LoginViewModel loginModel);
        void Cadastrar(CadastroViewModel cadastroModel);
    }
}
