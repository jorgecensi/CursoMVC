
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JLC.CursoMVC.Domain.Interfaces.Repository
{
    public interface Irepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);        
        TEntity OberPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();



    }
}
