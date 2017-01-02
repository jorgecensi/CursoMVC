
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Specifications.Clientes;

namespace JLC.CursoMvc.Domain.Tests.Specification
{
    [TestClass]
    public class CPFSpecification
    {
        public Cliente Cliente { get; set; }

        [TestMethod]
        public void CPF_Valido_True()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579912"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsTrue(cpf.IsSatisfiedBy(Cliente));

        }

        [TestMethod]
        public void CPF_Valido_False()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579911"
            };

            var cpf = new ClienteDeveTerCpfValidoSpecification();
            Assert.IsFalse(cpf.IsSatisfiedBy(Cliente));

        }
    }
}
