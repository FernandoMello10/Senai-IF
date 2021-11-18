using SenaiChamados.Models;
using SenaiChamados.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces.Application
{
    public interface IUsuarioApplication
    {
        IEnumerable<Usuario> GetAll();
        TokenViewModel Login(LoginViewModel loginModel);
        void Save(Usuario newModel);
        void Update(Usuario updatedModel);
        void Delete(int id);
        Usuario GetByID(int id);
    }
}
