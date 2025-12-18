using AnimeScript.Infrastructure;
using AnimeScript.Application;

var builder = WebApplication.CreateBuilder(args);

// 1. Injeção de Dependência: Conecta as camadas de Infra e Application
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Configuração do Swagger (Interface visual para testar a API)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();