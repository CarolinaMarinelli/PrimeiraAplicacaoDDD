using Carrefas.Application.Ioc;
using Carrefas.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? conection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarrefasContext>(options => options.UseMySql(
    conection, ServerVersion.AutoDetect(conection)));

builder.Services.AddResolveDependecies(); // vai fazer a injeção de dependencia 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
