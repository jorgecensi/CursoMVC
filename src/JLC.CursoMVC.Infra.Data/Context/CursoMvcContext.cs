
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace JLC.CursoMVC.Infra.Data.Context
{
    public class CursoMvcContext: DbContext 
    {
        //passa a connectionString da classe base para o nosso contexto
        //é a mesma connectionStrin do Identity
        public CursoMvcContext()
            :base("DefaultConnection")
        {

        }

        //informar quais classes o EF vai gerenciar
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        //sobrescrevendo o metodo OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //impede o EF de crias as tabelas no plural do Ingles 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // por padrão o EF faz o delete Cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Instruir ao EF a enconntrar quais são as Chaves Primárias
            //Toda propriedade de classe que tiver o nome da classe + Id ele considera como PK
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //quando a propriedade é uma string, ele cria o campo no banco como Varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            //e quando não for definido, o campo varchar é criado com no maximo 100 caracteres
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //para cada mudança no banco onde o campo é DataCadatro e estiver nula
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DataCadastro") != null))
            {
                //Quando adicionar recebe a data do servidor
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                }
                //bloqueia alteração  caso algum lugar tentar alterar a data 
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }
}
