
using JLC.CursoMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JLC.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente OberPorId(Guid id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);

    }
}
