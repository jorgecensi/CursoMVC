
using JLC.CursoMvc.Application;
using JLC.CursoMvc.Application.Interfaces;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using JLC.CursoMVC.Domain.Interfaces.Services;
using JLC.CursoMVC.Domain.Services;
using JLC.CursoMVC.Infra.Data.Context;
using JLC.CursoMVC.Infra.Data.Interfaces;
using JLC.CursoMVC.Infra.Data.Repository;
using JLC.CursoMVC.Infra.Data.Uow;
using SimpleInjector;

namespace JLC.CursoMvc.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        //Lifestyle.Transient => Uma instancia para cada solicitação
        //Lifestyle.Singleton => Uma instancia unica para a classe
        //Lifestyle.Scoped => Uma instancia unica para o request => OnePerRequest

        public static void RegisterServices(Container container)
        {
            //APP
           
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);


        } 

    }
}
