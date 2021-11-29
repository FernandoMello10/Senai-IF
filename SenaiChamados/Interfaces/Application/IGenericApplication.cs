using System.Collections.Generic;

namespace SenaiChamados.Interfaces.Application
{
    public interface IGenericApplication<TModel>
    {
        IEnumerable<TModel> BuscarTodos();
        TModel BuscarPorID(int id);
        void Salvar(TModel modeloNovo);
        void Atualizar(TModel modeloAtualizado);
        void Deletar(int id);
    }
}