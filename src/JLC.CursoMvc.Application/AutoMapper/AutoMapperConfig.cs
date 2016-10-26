using AutoMapper;
using JLC.CursoMvc.Application.ViewModels;
using JLC.CursoMVC.Domain.Entities;

namespace JLC.CursoMvc.Application.AutoMapper
{
    public class AutoMapperConfig
    {

        public static void RegisterMappings()
        {

            //Domain to ViewModel
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente, ClienteViewModel>();
                cfg.CreateMap<Cliente, ClienteEnderecoViewModel>();
                cfg.CreateMap<Endereco, EnderecoViewModel>();
                cfg.CreateMap<Endereco, ClienteEnderecoViewModel>();                

            //ViewModel to Domain
           
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<ClienteEnderecoViewModel, Cliente>();
                cfg.CreateMap<EnderecoViewModel, Endereco>();
                cfg.CreateMap<ClienteEnderecoViewModel, Endereco>();
                });

        }
    }
}
