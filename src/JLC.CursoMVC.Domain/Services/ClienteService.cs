using JLC.CursoMVC.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using JLC.CursoMVC.Domain.Validations.Clientes;

namespace JLC.CursoMVC.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
            {
                cliente.ValidationResult.Message = "Não foi possível cadastrar cliente!";
                return cliente;
            }
            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                cliente.ValidationResult.Message = "Não foi possível cadastrar cliente!";
                return cliente;
            }
            cliente.ValidationResult.Message = "Cliente cadastrado com sucesso :) ";

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            //TODO verificar necessidade de paginação
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
