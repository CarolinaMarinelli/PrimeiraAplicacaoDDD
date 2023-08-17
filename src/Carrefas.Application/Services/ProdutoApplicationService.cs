using Carrefas.Application.Interfaces;
using Carrefas.Application.ViewModels;
using Carrefas.Domain.Interfaces.Services;
using Carrefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoServices _produtoService;
        public ProdutoApplicationService(IProdutoServices produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task AdicionarProduto(ProdutoViewModel produtoViewModel)
        {

            var produto = new Produto(produtoViewModel.Nome,
                                      produtoViewModel.Descricao,
                                      produtoViewModel.Valor,
                                      produtoViewModel.Ativo);

            
            await _produtoService.AdicionarProduto(produto);
        }

        public Task AtualizarProduto(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> BuscarProdutoPeloId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoViewModel>> ListarTodosProdutos()
        {
            throw new NotImplementedException();
        }

        public Task RemoverProduto(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}

// o ID é gerado a partir que dou o new produto                     