using CrudSample.Domain.Entities.Empresas;
using System.Collections.Generic;

namespace CrudSample.Domain.Repository.Empresas
{
    public interface IEmpresaRepository
    {
        Task<IQueryable<Empresa>> FiltrarPorNomeAsync(string nome);
        Task<Empresa> FiltrarPorIdAsync(int id);
        Task CadastrarAsync(Empresa empresa);
        Task AtualizarAsync(Empresa empresa);
        Task DeletarAsync(Empresa empresa);
    }
}
