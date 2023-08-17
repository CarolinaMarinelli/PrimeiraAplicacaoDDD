using Carrefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
      
        Task Adicionar(T entity); //task é para ser usado de forma assíncrona 
        Task<T> ObterPorId(Guid id);
        Task<List<T>> ObterTodos();
        Task Atualizar(T entity);
        Task Remover (Guid id);    
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate); //expressao Lambda
        Task<int> SaveChanges(); //O que efetivamente salva no banco de dados

    }
}
