using DomainValidation.Validation;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using JLC.CursoMVC.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLC.CursoMVC.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation: Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDeveTerCpfUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDeveTerEmailUnicoSpecification(clienteRepository);
            var clienteEndereco = new ClienteDeveTerUmEnderecoSpecification();

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado! Esqueceu a senha?"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado! Esqueceu a senha?"));
            base.Add("clienteEndereco", new Rule<Cliente>(clienteEndereco, "Cliente não informou endereço"));
        }
    }
}
