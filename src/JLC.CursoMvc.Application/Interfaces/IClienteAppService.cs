
using JLC.CursoMvc.Application.ViewModels;
using JLC.CursoMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JLC.CursoMvc.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(Guid id);
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);

    }
}
