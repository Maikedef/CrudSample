using CrudSample.Domain.Entities.Usuarios;

namespace CrudSample.Domain.Repository.Usuarios
{
    public interface IUsuarioRepository
    {
        Task CadastrarAsync(Usuario usuario);
        Task<Usuario> AutenticarAsync(string nome, string senha);
    }
}
