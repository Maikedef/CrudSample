using CrudSample.Application.Cryptography;
using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.Services.Automapper.Usuarios;
using CrudSample.Application.Services.Token;
using CrudSample.Application.UseCase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudSample.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddDependenciasApplication(this IServiceCollection service, IConfiguration configuration)
        {
            string? chave = configuration.GetRequiredSection("Configuracoes:chave_adicional_senha").Value;
            
            service.AddScoped(option => new EncryptService(chave));

            string? chaveSeguranca = configuration.GetRequiredSection("Configuracoes:chave_seguranca").Value;
            string? tempoExpiracao = configuration.GetRequiredSection("Configuracoes:tempo_expiracao_token_minuto").Value;

            service.AddScoped(option => new TokenService(chaveSeguranca, double.Parse(tempoExpiracao)));
            
            service.AddScoped(option => new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(UsuarioMapper));
            }).CreateMapper());

            service.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
        }
    }
}
