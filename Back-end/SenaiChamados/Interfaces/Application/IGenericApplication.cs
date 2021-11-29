using System.Collections.Generic;

namespace SenaiChamados.Interfaces.Application
{
    public interface IGenericApplication<TModel, TEntity>
    {
        IEnumerable<TModel> BuscarTodos();
        TModel BuscarPorID(int id);
        void Salvar(TEntity modeloNovo);
        void Atualizar(TEntity modeloAtualizado);
        void Deletar(int id);
    }
}