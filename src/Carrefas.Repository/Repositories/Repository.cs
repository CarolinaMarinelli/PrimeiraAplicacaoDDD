using Carrefas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Carrefas.Repository.Context;
using Carrefas.Domain.Models;

namespace Carrefas.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly CarrefasContext Context; //Quem herar o repositório, também vai herdar a conexão com o banco de dados
        protected readonly DbSet<T> DbSet; //recurso para que em algum momento consiga ser mapeado

        public Repository(CarrefasContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }


        public async Task Adicionar(T entity)
        {
            DbSet.Add(entity); //fazendo a persistencia um produto no banco de dados (chamando o entity framework e falando para adicionar alguma coisa)
            await SaveChanges();    
        }

        public async Task Atualizar(T entity)
        {
            DbSet.Update(entity); 
            await SaveChanges();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();//O AsNoTracking não cria tracking de transação em memoria. o .Where é onde utiliza a expressão lambda, para obter a lista de alguma coisa
;                
        }

        public void Dispose()
        {
           Context.Dispose(); // para limpar a memória
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id); //quando da um Find, precisa passar o id
        }

        public Task<List<T>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync(); //vai efetivar a persistencia no banco de dados
        }
    }
}
