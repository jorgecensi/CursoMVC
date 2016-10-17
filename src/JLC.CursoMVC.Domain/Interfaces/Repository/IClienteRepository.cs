
using JLC.CursoMVC.Domain.Entities;

namespace JLC.CursoMVC.Domain.Interfaces.Repository
{
    public interface IClienteRepository : Irepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
    }
}
