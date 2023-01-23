using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.ViewsModels.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudSample.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase _usuarioUseCase;
        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] RegistrarUsuarioDto usuario)
        {
            var resp = await _usuarioUseCase.ContemUsuarioCadastradoAsync();

            IActionResult result;
            RespostaUsuarioAutenticadoDto? usuarioAutenticadoDto;

            if (!resp)
            {
                usuario.Role = "admin";
                usuarioAutenticadoDto = await _usuarioUseCase.CadastrarAsync(usuario);
                result = Ok(usuarioAutenticadoDto);
            }
            else
            {
                bool eAdmin = User.IsInRole("admin");

                if (eAdmin)
                {
                    usuarioAutenticadoDto = await _usuarioUseCase.CadastrarAsync(usuario);
                    result = Ok(usuarioAutenticadoDto);
                }
                else
                {
                    result = Unauthorized();
                }
            }
            return result;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public async Task<IActionResult> AutenticarAsync([FromBody] AutenticarUsuarioDto autenticarUsuarioDto)
        {
            var resp = await _usuarioUseCase.AutenticarAsync(autenticarUsuarioDto);
            return Ok(resp);
        }
    }
}
