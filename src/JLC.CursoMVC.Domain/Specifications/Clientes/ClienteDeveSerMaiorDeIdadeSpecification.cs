
using System;
using DomainValidation.Interfaces.Specification;
using JLC.CursoMVC.Domain.Entities;

namespace JLC.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}
