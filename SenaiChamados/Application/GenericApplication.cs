using SenaiChamados.Interfaces;
using SenaiChamados.Interfaces.Application;
using System.Collections.Generic;
using System.Linq;

namespace SenaiChamados.Application
{
    public abstract class GenericApplication<TModel, TEntity> : IGenericApplication<TModel, TEntity> 
        where TModel : class where TEntity : class
    {
        private IGenericRepository<TEntity> _repo { get; set; }

        public GenericApplication(IGenericRepository<TEntity> repositorio)
        {
            _repo = repositorio;
        }

        public void Atualizar(TEntity modeloAtualizado)
        {
            _repo.Atualizar(modeloAtualizado);
        }

        public TModel BuscarPorID(int id)
        {
            return BuildModel(_repo.BuscarPorID(id));
        }

        public IEnumerable<TModel> BuscarTodos()
        {
            return _repo.BuscarTodos().Select(dto => BuildModel(dto));
        }

        public void Salvar(TEntity modeloNovo)
        {
            _repo.Salvar(modeloNovo);
        }

        public void Deletar(int id)
        {
            _repo.Deletar(id);
        }

        protected abstract TModel BuildModel(TEntity dto);
    }
}
