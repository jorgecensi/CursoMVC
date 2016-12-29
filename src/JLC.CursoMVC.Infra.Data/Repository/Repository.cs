
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using JLC.CursoMVC.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;

namespace JLC.CursoMVC.Infra.Data.Repository
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        protected CursoMvcContext Db;
        protected DbSet<Tentity> DbSet;

        public Repository(CursoMvcContext context)
        {
            //criando um atalho, para não digitar Set<Tentity>() em todo método
            Db = context;
            DbSet = Db.Set<Tentity>();
        }

        public virtual Tentity Adicionar(Tentity obj)
        {
            //adiciona na memória do EF
            var objReturn = DbSet.Add(obj); 
            return objReturn;
        }

        public virtual Tentity Atualizar(Tentity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;           

            return obj;
        }

        public IEnumerable<Tentity> Buscar(Expression<Func<Tentity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }       

        public virtual Tentity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<Tentity> ObterTodos()//(int inicio, int qtd) 
        {
            return DbSet.ToList(); //Take(qtd).Skip(inicio).ToList(); 
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));           
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
