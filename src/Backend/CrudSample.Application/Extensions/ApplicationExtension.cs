using CrudSample.Application.Cryptography;
using CrudSample.Application.Interfaces.Usuarios;
using CrudSample.Application.Services.Automapper.Empresas;
using CrudSample.Application.Services.Automapper.Usuarios;
using CrudSample.Application.Services.Token;
using CrudSample.Application.UseCase.Empresas;
using CrudSample.Application.UseCase.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
                cfg.AddProfile(typeof(EmpresaMapper));
            }).CreateMapper());

            service.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
            service.AddScoped<IEmpresaUseCase, EmpresaUseCase>();

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(chaveSeguranca)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
