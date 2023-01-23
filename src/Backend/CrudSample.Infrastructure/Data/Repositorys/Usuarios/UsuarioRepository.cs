using CrudSample.Domain.Entities.Usuarios;
using CrudSample.Domain.Repository.Usuarios;
using CrudSample.Domain.Repositorys.UoW;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Infrastructure.Data.Repositorys.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CrudSampleDbContext _context;

        private readonly IUnityOfWork _unityOfWork;

        public UsuarioRepository(CrudSampleDbContext context, IUnityOfWork unityOfWork)
        {
            _context = context;
            _unityOfWork = unityOfWork;
        }
        public async Task<Usuario?> AutenticarAsync(string nome, string senha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Nome == nome && x.Senha == senha);
        }

        public async Task CadastrarAsync(Usuario? usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _unityOfWork.CommitAsync();
        }

        public async Task<bool> ContemUsuarioCadastradoAsync()
        {
            return await _context.Usuarios.AnyAsync();
        }
    }
}
