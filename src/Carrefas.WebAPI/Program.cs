using Carrefas.Application.Ioc;
using Carrefas.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string? conection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarrefasContext>(options => options.UseMySql(
    conection, ServerVersion.AutoDetect(conection)));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResolveDependecies(); // vai fazer a injeção de dependencia 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
