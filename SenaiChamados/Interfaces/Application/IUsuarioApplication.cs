using SenaiChamados.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces.Application
{
    public interface IUsuarioApplication
    {
        IEnumerable<User> GetAll();
        void Save(User newModel);
        void Update(User updatedModel);
        void Delete(int id);
        User GetByID(int id);
        bool Login(string email, string password);
    }
}
