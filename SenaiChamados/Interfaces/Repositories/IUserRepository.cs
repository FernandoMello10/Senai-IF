using SenaiChamados.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiChamados.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool Login(string email, string password);
    }
}
