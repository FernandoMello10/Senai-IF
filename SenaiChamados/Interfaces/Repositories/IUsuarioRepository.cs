using SenaiChamados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario BuscarEmailSenha(string email, string senha);
    }
}
