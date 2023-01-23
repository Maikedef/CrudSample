using CrudSample.Application.ViewsModels.Empresas;
using CrudSample.Domain.Entities.Empresas;

namespace CrudSample.Application.Interfaces.Usuarios
{
    public interface IEmpresaUseCase
    {
        Task<List<ObterEmpresaDto>> FiltrarPorNomeAsync(string nome);
        Task<ObterEmpresaDto> FiltrarPorIdAsync(int id);
        Task CadastrarAsync(CadastrarEmpresaDto empresa);
        Task AtualizarAsync(AtualizarEmpresaDto empresa);
        Task DeletarAsync(int id);
    }
}
