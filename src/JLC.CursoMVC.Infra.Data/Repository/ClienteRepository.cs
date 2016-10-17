using System;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using System.Linq;

namespace JLC.CursoMVC.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterPorCpf(string cpf)
        {
            //return Db.Clientes.FirstOrDefault(c => c.CPF == cpf);
            //return Buscar(c => c.CPF == cpf).SingleOrDefault(); //somente o registro unico
            return Buscar(c => c.CPF == cpf).FirstOrDefault(); //pego o primero da fila
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(e => e.Email == email).FirstOrDefault();
        }

        ////excluir sem remover da base
        //public override void Remover(Guid id)
        //{
        //    //precisa ter um campo chamado Excluido na tabela
        //    Db.Clientes.Find(id).Excluido == true;
        //    SaveChanges();
        //}
    }
}
