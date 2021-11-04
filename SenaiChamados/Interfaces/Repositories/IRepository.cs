using System.Collections.Generic;

namespace SenaiChamados.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Save(T newModel);
        void Update(T updatedModel);
        void Delete(int id);
        T GetByID(int id);
        IEnumerable<T> GetAll();
    }
}
