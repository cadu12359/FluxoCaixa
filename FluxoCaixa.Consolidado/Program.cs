using FluxoCaixa.Consolidado.Application.Interfaces;
using FluxoCaixa.Consolidado.Application.UseCases;
using FluxoCaixa.Lancamentos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// Injeção de dependências
builder.Services.AddScoped<IObterConsolidadoDiario, ObterConsolidadoDiarioUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("consolidado", new OpenApiInfo { Title = "FluxoCaixa Consolidado", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/consolidado/swagger.json", "FluxoCaixa Consolidado v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();