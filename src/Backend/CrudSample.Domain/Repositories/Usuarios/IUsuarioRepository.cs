using CrudSample.Domain.Entities.Usuarios;

namespace CrudSample.Domain.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task CadastrarAsync(Usuario? usuario);
        Task<Usuario?> AutenticarAsync(string nome, string senha);
        Task<bool> ContemUsuarioCadastradoAsync();
    }
}
