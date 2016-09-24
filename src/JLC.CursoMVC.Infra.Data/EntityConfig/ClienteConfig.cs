

using JLC.CursoMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace JLC.CursoMVC.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        //Fluent API

        public ClienteConfig()
        {
            //PK
            HasKey(c => c.ClienteId);

            //exemplo de chave composta
            //HasKey(c => new { c.ClienteId, c.CPF });

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true}));

            ToTable("Clientes");
            
        }

    }
}
