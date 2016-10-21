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
            Mapper.Initialize(cfg => cfg.CreateMap<Cliente, ClienteViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<Cliente, ClienteEnderecoViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<Endereco, EnderecoViewModel>());
            Mapper.Initialize(cfg => cfg.CreateMap<Endereco, ClienteEnderecoViewModel>());

            //ViewModel to Domain
            Mapper.Initialize(cfg => cfg.CreateMap<ClienteViewModel, Cliente>());
            Mapper.Initialize(cfg => cfg.CreateMap<ClienteEnderecoViewModel, Cliente>());
            Mapper.Initialize(cfg => cfg.CreateMap<EnderecoViewModel, Endereco>());
            Mapper.Initialize(cfg => cfg.CreateMap<ClienteEnderecoViewModel, Endereco>());

        }
    }
}
