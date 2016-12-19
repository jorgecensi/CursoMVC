
using JLC.CursoMVC.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JLC.CursoMVC.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {

        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
