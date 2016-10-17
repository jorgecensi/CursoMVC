using JLC.CursoMvc.Application.Interfaces;
using System;
using System.Collections.Generic;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Infra.Data.Repository;

namespace JLC.CursoMvc.Application
{
    /// <summary> Classe de serviço de aplicação que dá acesso as consultas do repositorio
    /// 
    /// </summary>    
    class ClienteAppService : IClienteAppService
    {
        private readonly ClienteRepository _clienteRepository = new ClienteRepository();

        public Cliente Adicionar(Cliente cliente)
        {
            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Cliente OberPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
