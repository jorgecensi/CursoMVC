using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JLC.CursoMVC.Domain.Entities;
using System.Linq;

namespace JLC.CursoMvc.Domain.Tests.Entity
{
    [TestClass]
    public class ClienteTest
    {
        // preparar o objeto

        public Cliente Cliente { get; set; }


        [TestMethod]
        public void ClienteConsistente_Valid_True()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579912",
                DataNascimento = new DateTime(1987, 02, 09),
                Email = "cliente@cliente.com"
            };

            Assert.IsTrue(Cliente.IsValid());
        }

        [TestMethod]
        public void ClienteConsistente_Valid_False()
        {
            Cliente = new Cliente()
            {
                CPF = "05665579910",
                DataNascimento = new DateTime(2015, 02, 09),
                Email = "cliente2cliente.com"
            };

            Assert.IsFalse(Cliente.IsValid());
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido"));
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um e-mail inválido"));
            Assert.IsTrue(Cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente não tem maioridade para o cadastro"));
        }
    }
}
