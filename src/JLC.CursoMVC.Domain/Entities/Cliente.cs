using System;
using System.Collections.Generic;

namespace JLC.CursoMVC.Domain.Entities
{
    public class Cliente
    {

        public Cliente()
        {
            ClienteId = Guid.NewGuid();
            //new List - quando for necessário adicionar um novo endereço, não será necessário instanciar a coleção
            Enderecos = new List<Endereco>();
        }


        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        //propriedade virtual: significa que pode ser sobreescrita
        // também utilizada para utilizar o lazyloading
        public virtual ICollection<Endereco> Enderecos { get; set; }


    }
}
