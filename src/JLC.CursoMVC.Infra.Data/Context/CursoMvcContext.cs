
using JLC.CursoMVC.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            base.OnModelCreating(modelBuilder);
        }

    }
}
