using SenaiChamados.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<UsuarioDTO>
    {
        UsuarioDTO BuscarEmailSenha(string email, string senha);
        UsuarioDTO BuscarPorEmail(string email);
    }
}
