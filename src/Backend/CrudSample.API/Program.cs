using CrudSample.Infrastructure.Data.Migrations;
using CrudSample.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Database.CriarDatabase(builder.Configuration.ObterStringConexao(), builder.Configuration.ObterNomeDatabase());

builder.Services.AddFluentMigrator(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateBancoDados();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
