using System;

namespace JLC.CursoMVC.Domain.Entities
{
    public class Endereco
    {
        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }

        public Guid EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
        
        //fk da tabela Cliente
        public Guid ClienteId { get; set; }

        //propriedade virtual: significa que pode ser sobreescrita
        // também utilizada para utilizar o lazyloading
        public virtual Cliente Cliente { get; set; }


    }
}
