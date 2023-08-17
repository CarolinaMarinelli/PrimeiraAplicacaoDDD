using Carrefas.Application.Interfaces;
using Carrefas.Application.Services;
using Carrefas.Domain.Interfaces;
using Carrefas.Domain.Interfaces.Notifications;
using Carrefas.Domain.Interfaces.Services;
using Carrefas.Domain.Notifications;
using Carrefas.Domain.Services;
using Carrefas.Repository.Context;
using Carrefas.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Carrefas.Application.Ioc
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddResolveDependecies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<CarrefasContext>();

            
            //Domain - fazendo o mapeamento - o generico não precisa implementar
            services.AddScoped<IProdutoRepository, ProdutoRepositories>();
            services.AddScoped<IProdutoServices, ProdutoService>();                
            services.AddScoped<INotifier, Notifier>();


            //Application
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();

            return services;


        }

    }
}

//quando uma classe possui o static na frente não precisa fazer uma nova instancia dela 
// IServiceColletion é uma interface do proprio .Net
// Aqui consegue resolver as dependencias entre a interface e a classe que implementar ela