
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using JLC.CursoMVC.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Linq;

namespace JLC.CursoMvc.Domain.Tests.Validation
{
    [TestClass]
    public class ClienteAptoParaCadastroTest
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void ClienteApto_Validade_True()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579912",
                Email = "jorge@jorge.com"
            };

            Cliente.Enderecos.Add(new Endereco());

            //cria um repositorio falso
            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(null);
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(null);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);

            Assert.IsTrue(cliValidation.Validate(Cliente).IsValid);
        }


        [TestMethod]
        public void ClienteApto_Validade_False()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579912",
                Email = "jorge@jorge.com"
            };

            

            //cria um repositorio falso
            var stubRepo = MockRepository.GenerateStub<IClienteRepository>();
            stubRepo.Stub(s => s.ObterPorEmail(Cliente.Email)).Return(Cliente);
            stubRepo.Stub(s => s.ObterPorCpf(Cliente.CPF)).Return(Cliente);

            var cliValidation = new ClienteAptoParaCadastroValidation(stubRepo);
            var result = cliValidation.Validate(Cliente);

            Assert.IsFalse(cliValidation.Validate(Cliente).IsValid);
            Assert.IsTrue(result.Erros.Any(e => e.Message == "CPF já cadastrado! Esqueceu a senha?"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "E-mail já cadastrado! Esqueceu a senha?"));
        }
    }
}
