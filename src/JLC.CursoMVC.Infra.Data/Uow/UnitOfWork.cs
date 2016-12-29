
using System;
using JLC.CursoMVC.Infra.Data.Interfaces;
using JLC.CursoMVC.Infra.Data.Context;

namespace JLC.CursoMVC.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork   
    {
        private readonly CursoMvcContext _context;
        private bool _disposed;

        public UnitOfWork(CursoMvcContext context)
        {
            _context = context;

        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges(); 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true; 
            }
        }
    }
}
