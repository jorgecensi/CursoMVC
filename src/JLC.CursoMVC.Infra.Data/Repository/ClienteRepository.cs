using System;
using JLC.CursoMVC.Domain.Entities;
using JLC.CursoMVC.Domain.Interfaces.Repository;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using JLC.CursoMVC.Infra.Data.Context;

namespace JLC.CursoMVC.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CursoMvcContext context)
            :base(context)
        {

        }

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

        //Utilizando o Dapper para consultas


        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes";

            return cn.Query<Cliente>(sql);

        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Clientes c " +
                         " INNER JOIN Enderecos e" +
                        "          ON c.ClienteId = e.ClienteId " +
                        "       WHERE c.ClienteId = @sid";

            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");

            return cliente.FirstOrDefault(); 
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
