using System.Collections.Generic;

namespace SenaiChamados.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorID(int id);
        void Salvar(T modeloNovo);
        void Atualizar(T modeloAtualizado);
        void Deletar(int id);
    }
}
