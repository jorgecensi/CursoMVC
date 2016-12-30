
using System;
using DomainValidation.Interfaces.Specification;
using JLC.CursoMVC.Domain.Entities;
using System.Linq;

namespace JLC.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDeveTerUmEnderecoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Enderecos != null && cliente.Enderecos.Any();
        }
    }
}
