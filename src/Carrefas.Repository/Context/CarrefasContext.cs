using Carrefas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Carrefas.Repository.Context
{
    public class CarrefasContext : DbContext
    {
        public CarrefasContext(DbContextOptions<CarrefasContext> options) : base(options)

        {

        }
        public DbSet<Produto> Produtos { get; set; } // vai mapear para o banco de dados
       

        protected override void OnModelCreating(ModelBuilder modelBuilder) //ModelBuilder também percente ao entity framework core
        {

            // Verificar o API Fluent qu foi criado e caso alguma propriedade não estiver setado ColumnType, por default
            // coloca a propriedade como string de 100 caracteres (varchar 100)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");


            // Obter todo o mapeamento realizado utilizando - Olha o contexto e verifica quais são os DbSet que estão usando
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarrefasContext).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


        }
    }


    
}

//toda vez que tiver um override é que ele está sobrescrevendo alguma coisa 