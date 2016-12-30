
using System;
using DomainValidation.Interfaces.Specification;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Validations.Documentos;

namespace JLC.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validate(cliente.Email);
        }
    }
}
