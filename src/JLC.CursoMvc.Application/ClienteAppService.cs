using JLC.CursoMvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Infra.Data.Repository;
using JLC.CursoMvc.Application.ViewModels;
using AutoMapper;
using JLC.CursoMVC.Domain.Interfaces.Services;
using JLC.CursoMVC.Infra.Data.Interfaces;

namespace JLC.CursoMvc.Application
{
    /// <summary> Classe de serviço de aplicação que dá acesso as consultas do repositorio
    /// 
    /// </summary>    
    public class ClienteAppService : AppService,IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            :base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);

            BeginTransaction();
            _clienteService.Adicionar(cliente);
            //Se o dominio não reclamar de nada, faz o commit.
            Commit();

            return clienteEnderecoViewModel;

        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            _clienteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            return clienteViewModel;
        }

        

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
