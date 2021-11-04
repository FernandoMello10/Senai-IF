using SenaiChamados.Domain;
using SenaiChamados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Save(User newModel)
        {
            throw new NotImplementedException();
        }

        public void Update(User updatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
