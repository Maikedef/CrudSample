using Bogus;
using Bogus.Extensions.Brazil;
using CrudSample.Application.ViewsModels.Empresas;
using CrudSample.Application.ViewsModels.Usuarios;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CrudSample.Test.Empresas
{
    public class EmpresaAPITest : ControllerBase
    {
        public EmpresaAPITest(CrudSampleWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        private async Task<string> AutenticarUsuario()
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
            var result = await resposta.Content.ReadAsStringAsync();

            var resp = JsonConvert.DeserializeObject<RespostaUsuarioAutenticadoDto>(result);
            return resp.Token;
        }

        [Fact]
        public async Task Validar_Sucesso_Cadastrar_Empresa()
        {
            const string METODO = "api/empresas";
            var cadastrarEmpresa = new Faker<CadastrarEmpresaDto>()
                .RuleFor(c => c.Nome, f => f.Company.CompanyName())
                .RuleFor(c => c.Cnpj, f => f.Company.Cnpj())
                .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber());

            var endereco = new Faker<EnderecoDto>()
               .RuleFor(c => c.Logradouro, f => f.Address.StreetAddress())
                .RuleFor(c => c.Numero, f => f.Random.Int(1, 100).ToString())
                .RuleFor(c => c.Cidade, f => f.Address.City())
                .RuleFor(c => c.Estado, f => f.Address.State());

            var cadastrarEmpresaDto = cadastrarEmpresa.Generate();
            cadastrarEmpresaDto.Endereco = endereco.Generate();
            cadastrarEmpresaDto.Endereco.Bairro = "teste";
            cadastrarEmpresaDto.EnderecoId = 1;

            string token = await AutenticarUsuario();

            var resposta = await PostRequest(METODO, cadastrarEmpresaDto, token);

            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


        [Fact]
        public async Task Validar_Sucesso_Alterar_Empresa()
        {
            const string METODO = "api/empresas";
            var atualizarEmpresa = new Faker<AtualizarEmpresaDto>()
                .RuleFor(c => c.Nome, f => f.Company.CompanyName())
                .RuleFor(c => c.Cnpj, f => f.Company.Cnpj())
                .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber());

            var endereco = new Faker<EnderecoDto>()
               .RuleFor(c => c.Logradouro, f => f.Address.StreetAddress())
                .RuleFor(c => c.Numero, f => f.Random.Int(1, 100).ToString())
                .RuleFor(c => c.Cidade, f => f.Address.City())
                .RuleFor(c => c.Estado, f => f.Address.State());

            var atualizarEmpresaDto = atualizarEmpresa.Generate();
            atualizarEmpresaDto.Endereco = endereco.Generate();
            atualizarEmpresaDto.Endereco.Bairro = "teste";
            atualizarEmpresaDto.Id = 1;

            string token = await AutenticarUsuario();

            var resposta = await PutRequest(METODO, atualizarEmpresaDto, token);

            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Validar_Sucesso_Deletar_Empresa()
        {
            const string METODO = "api/empresas/2";
            string token = await AutenticarUsuario();
            var resposta = await DeleteRequest(METODO, autorization: token);
            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Validar_Sucesso_Obter_EmpresaId()
        {
            const string METODO = "api/empresas/1";
            string token = await AutenticarUsuario();
            var resposta = await GetRequestRoute(METODO, token);
            resposta.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Validar_Sucesso_Obter_EmpresaNome()
        {
            const string METODO = "api/empresas";

            string parametroNome = "nome";
            string paramentroValue = "Coca";
            string token = await AutenticarUsuario();

            var resposta = await GetRequestQuery(METODO, parametroNome, paramentroValue, token);
        }
    }
}
