using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.ViewsModels.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CrudSample.API.Controllers
{
    [ApiController]
    [Route("api/v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase _usuarioUseCase;
        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] RegistrarUsuarioDto usuario)
        {
            var resp = await _usuarioUseCase.CadastrarAsync(usuario);
            return Ok(resp);
        }

        [HttpPost("oauth")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OauthAsync([FromBody] AutenticarUsuarioDto autenticarUsuarioDto)
        {
            var resp = await _usuarioUseCase.AutenticarAsync(autenticarUsuarioDto);
            return Ok(resp);
        }
    }
}
