using Carrefas.Domain.Models;
using System.Linq.Expressions;

namespace Carrefas.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto> //Criei um repositório especificado para o Produto e herdei o genérico, passando que quem vai consumir é a classe produto 
    {                                 
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task RemoverProduto(Guid id);       
        Task<IEnumerable<Produto>> BuscarProduto(Expression <Func<Produto, bool>> expression);
    }
}
