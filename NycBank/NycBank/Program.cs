using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NycBank.Data;
using NycBank.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexao = "User Id=rm95546;Password=170599;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

builder.Services.AddDbContext<BankContext>(options =>
    options.UseOracle(stringConexao));

builder.Services.AddCors();

// Configuração do aplicativo
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();
app.MapControllers();

app.Run();
