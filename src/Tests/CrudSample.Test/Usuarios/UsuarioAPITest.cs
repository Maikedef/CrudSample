using Bogus;
using CrudSample.Application.ViewsModels.Usuarios;
using CrudSample.Domain.Entities.Usuarios;
using FluentAssertions;
using Xunit;

namespace CrudSample.Test.Usuarios
{
    public class UsuarioAPITest: ControllerBase
    {
        public UsuarioAPITest(CrudSampleWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Validar_Sucesso_Cadastrar_Usuario()
        {
            const string METODO = "api/usuarios";
            var registrarUsuario = new Faker<RegistrarUsuarioDto>()
                .RuleFor(c => c.Nome, f => f.Name.FirstName());

            var usuario = registrarUsuario.Generate();
            usuario.Senha = "123456";
            usuario.Role = "admin";

            var resposta = await PostRequest(METODO, usuario);

            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Validar_Sucesso_Autenticar_Usuario()
        {
            const string METODO = "api/usuarios/login";
            var autenticarUsuario = new AutenticarUsuarioDto();
            autenticarUsuario.Nome = "teste";
            autenticarUsuario.Senha = "123456";

            var registrarUsuarioDto = new RegistrarUsuarioDto();
            registrarUsuarioDto.Nome = "teste";
            registrarUsuarioDto.Senha = "123456";
            registrarUsuarioDto.Role = "admin";

            await PostRequest("api/usuarios", registrarUsuarioDto);

            var resposta = await PostRequest(METODO, autenticarUsuario);
            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
