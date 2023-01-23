using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.ViewsModels.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudSample.API.Controllers.Empresas
{
    [ApiController]
    [Route("api/empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaUseCase _empresaUseCase;

        public EmpresaController(IEmpresaUseCase empresaUseCase)
        {
            _empresaUseCase = empresaUseCase;
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> FiltrarPorNomeAsync([FromQuery] string nome)
        {
            var resp = await _empresaUseCase.FiltrarPorNomeAsync(nome);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> FiltrarPorIdAsync([FromRoute] int id)
        {
            var resp = await _empresaUseCase.FiltrarPorIdAsync(id);
            return Ok(resp);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CadastrarAsync([FromBody] CadastrarEmpresaDto cadastrarEmpresaDto)
        {
            await _empresaUseCase.CadastrarAsync(cadastrarEmpresaDto);
            return Ok("Empresa cadastrada com êxito");
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarEmpresaDto atualizarEmpresaDto)
        {
            await _empresaUseCase.AtualizarAsync(atualizarEmpresaDto);
            return Ok("Empresa atualizada com êxito");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletarAsync([FromRoute] int id)
        {
            await _empresaUseCase.DeletarAsync(id);
            return Ok("Empresa deletada com êxito");
        }
    }
}
