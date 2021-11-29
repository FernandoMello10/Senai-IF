using SenaiChamados.Interfaces;
using SenaiChamados.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Repositories
{
    public class UsuarioRepository : GenericRepository<UsuarioDTO>, IUsuarioRepository
    {
        public UsuarioRepository(SenaiChamadosContext ctx) : base(ctx) { }

        public UsuarioDTO BuscarEmailSenha(string email, string senha)
        {
            return _ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public UsuarioDTO BuscarPorEmail(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(x => x.Email == email);
        }
    }
}
