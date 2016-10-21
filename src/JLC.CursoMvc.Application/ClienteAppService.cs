using JLC.CursoMvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Infra.Data.Repository;
using JLC.CursoMvc.Application.ViewModels;
using AutoMapper;

namespace JLC.CursoMvc.Application
{
    /// <summary> Classe de serviço de aplicação que dá acesso as consultas do repositorio
    /// 
    /// </summary>    
    public class ClienteAppService : IClienteAppService
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            
            _clienteRepository.Adicionar(cliente);

            return clienteEnderecoViewModel;

        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
             _clienteRepository.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel));
            return clienteViewModel;
        }

        

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.OberPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
