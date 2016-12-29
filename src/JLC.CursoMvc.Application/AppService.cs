
using JLC.CursoMVC.Infra.Data.Interfaces;

namespace JLC.CursoMvc.Application
{
    public class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }
    }
}
