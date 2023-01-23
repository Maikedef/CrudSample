using CrudSample.Application.Extensions;
using CrudSample.Infrastructure.Data;
using CrudSample.Infrastructure.Data.Migrations;
using CrudSample.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Crud Sample", Version = "1.0" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "Jwt Authorization header utilizando o bearer scheme. Example \"Authorization: Bearer {token}\""
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});






builder.Services.AddFluentMigrator(builder.Configuration);
builder.Services.AddDependenciasInfrastructure(builder.Configuration);
builder.Services.AddDependenciasApplication(builder.Configuration);

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var context = serviceScope.ServiceProvider.GetService<CrudSampleDbContext>();
bool? dbInMemory = context?.Database?.ProviderName?.Equals("Microsoft.EntityFrameworkCore.InMemory");

if(!dbInMemory.HasValue || !dbInMemory.Value)
{
    Database.CriarDatabase(builder.Configuration.ObterStringConexao(), builder.Configuration.ObterNomeDatabase());
    app.MigrateBancoDados();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }