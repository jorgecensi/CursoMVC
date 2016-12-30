using DomainValidation.Validation;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Specifications.Clientes;

namespace JLC.CursoMVC.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido"));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail,"Cliente informou um e-mail inválido"));
            base.Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maioridade para o cadastro"));
        }
    }
}
