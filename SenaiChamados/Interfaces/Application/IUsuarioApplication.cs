using SenaiChamados.Domain;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces.Application
{
    public interface IUsuarioApplication
    {
        IEnumerable<UsuarioDTO> BuscarTodos();
        TokenViewModel Login(LoginViewModel loginModel);
        void Cadastrar(UsuarioDTO modeloNovo);
        void Atualizar(UsuarioDTO modeloAtualizado);
        void Deletar(int id);
        UsuarioDTO BuscarPorID(int id);
        void Cadastrar(CadastroViewModel cadastroModel);
    }
}
