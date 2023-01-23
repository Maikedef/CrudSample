using CrudSample.Domain.Entities.Empresas;
using CrudSample.Domain.Repositories.Empresas;
using CrudSample.Domain.Repositories.UoW;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Infrastructure.Data.Repositories.Empresas
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly CrudSampleDbContext _context;
        private readonly IUnityOfWork _unityOfWork;

        public EmpresaRepository(CrudSampleDbContext context, IUnityOfWork unityOfWork)
        {
            _context = context;
            _unityOfWork = unityOfWork;
        }
        public async Task AtualizarAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            await _unityOfWork.CommitAsync();

        }

        public async Task CadastrarAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _unityOfWork.CommitAsync();
        }

        public async Task DeletarAsync(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            await _unityOfWork.CommitAsync();
        }

        public async Task<Empresa> FiltrarPorIdAsync(int id)
        {
            return await _context.Empresas.Include(x => x.Endereco).AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<IQueryable<Empresa>> FiltrarPorNomeAsync(string nome)
        {
            return await Task.FromResult(_context.Empresas.Include(e => e.Endereco).AsNoTracking().Where(x => x.Nome.Contains(nome)));
        }
    }
}
