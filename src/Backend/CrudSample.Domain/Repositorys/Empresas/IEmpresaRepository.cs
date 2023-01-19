using CrudSample.Domain.Entities.Empresas;

namespace CrudSample.Domain.Repository.Empresas
{
    public interface IEmpresaRepository
    {
        Task<Empresa> FiltrarPorNomeAsync(string nome);
        Task<Empresa> FiltrarPorIdAsync(int id);
        Task CadastrarAsync(Empresa empresa);
        Task AtualizarAsync(Empresa empresa);
        Task DeletarAsync(int id);
    }
}
