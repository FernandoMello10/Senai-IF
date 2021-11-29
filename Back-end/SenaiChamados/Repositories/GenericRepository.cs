using Microsoft.EntityFrameworkCore;
using SenaiChamados.Domain;
using SenaiChamados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SenaiChamados.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public SenaiChamadosContext _ctx { get; set; }
        private static Type TipoItem => typeof(TEntity);
        private static PropertyInfo PropriedadeId => TipoItem.GetProperty("Id");

        public GenericRepository(SenaiChamadosContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _ctx.Set<TEntity>();
        }

        public TEntity BuscarPorID(int id)
        {
            return _ctx.Set<TEntity>().FirstOrDefault(x => PropriedadeId.GetValue(x).Equals(id));
        }

        public void Salvar(TEntity itemNovo)
        {
            _ctx.Set<TEntity>().Add(itemNovo);
            _ctx.SaveChanges();
        }

        public void Atualizar(TEntity itemNovo)
        {
             var itemAntigo = _ctx.Set<TEntity>().FirstOrDefault(x => PropriedadeId.GetValue(x).Equals(PropriedadeId.GetValue(x)));

            Modificar(itemAntigo, itemNovo);

            _ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            _ctx.Set<TEntity>().Remove(_ctx.Set<TEntity>().FirstOrDefault(x => PropriedadeId.GetValue(x).Equals(id)));
            _ctx.SaveChanges();
        }

        private static void Modificar<T>(T modeloAntigo, T modeloNovo)
        {
            foreach (var propriedade in modeloAntigo.GetType().GetProperties()) 
            {
                var valorAntigo = propriedade.GetValue(modeloAntigo);
                var valorNovo = propriedade.GetValue(modeloNovo);

                if (!Equals(valorAntigo, valorNovo))
                    propriedade.SetValue(modeloAntigo, valorNovo);
            }
        }
    }
}
