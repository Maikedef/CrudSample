using CrudSample.Application.ViewsModels.Usuarios;

namespace CrudSample.Application.Interfaces.Usuarios
{
    public interface IUsuarioUseCase
    {
        Task<RespostaUsuarioAutenticadoDto> CadastrarAsync(RegistrarUsuarioDto? usuarioDto);
        Task<RespostaUsuarioAutenticadoDto> AutenticarAsync(AutenticarUsuarioDto autenticarUsuarioDto);
        Task<bool> ContemUsuarioCadastradoAsync();
    }
}
