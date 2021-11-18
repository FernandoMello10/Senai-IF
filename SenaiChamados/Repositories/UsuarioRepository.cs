using SenaiChamados.Interfaces;
using SenaiChamados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SenaiChamadosContext _ctx; 

        public UsuarioRepository(SenaiChamadosContext ctx)
        {
            _ctx = ctx;
        }

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            return _ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Save(Usuario newModel)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
