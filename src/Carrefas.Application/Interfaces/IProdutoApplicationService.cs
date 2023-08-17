using Carrefas.Application.ViewModels;
using Carrefas.Domain.Models;
using System.Collections;

namespace Carrefas.Application.Interfaces
{
    public interface IProdutoApplicationService
    {
        Task AdicionarProduto(ProdutoViewModel produtoViewModel);
        Task AtualizarProduto(ProdutoViewModel produtoViewModel);
        Task<IEnumerable<ProdutoViewModel>> ListarTodosProdutos();
        Task<ProdutoViewModel> BuscarProdutoPeloId(Guid id);
        Task RemoverProduto(Guid id);
      
    }
}
