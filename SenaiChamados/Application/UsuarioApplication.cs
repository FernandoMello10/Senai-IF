using SenaiChamados.Helpers;
using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using SenaiChamados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Save(Usuario newModel)
        {
            newModel.Senha = CrytographyHelper.CreateMD5(newModel.Senha);

            _repo.Save(newModel);
        }

        public void Update(Usuario updatedModel)
        {
            _repo.Update(updatedModel);
        }

        IEnumerable<Usuario> IUsuarioApplication.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
