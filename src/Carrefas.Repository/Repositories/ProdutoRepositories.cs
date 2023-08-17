using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Carrefas.Domain.Interfaces;
using Carrefas.Domain.Models;
using Carrefas.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Carrefas.Repository.Repositories
{
    public class ProdutoRepositories : Repository<Produto>, IProdutoRepository //Aqui herdou o repository e implantou a interface
    {
        public ProdutoRepositories(CarrefasContext context) : base(context)
        {
        }

       public async Task AdicionarProduto(Produto produto)
        {
            await Adicionar(produto);
        }

        public async Task<IEnumerable<Produto>> BuscarProduto(Expression<Func<Produto, bool>> expression)
        {
            return await Context.Produtos.AsNoTracking().Where(expression).ToListAsync();  
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await Atualizar(produto);
        }

        public async Task RemoverProduto(Guid id)
        {
            await Remover(id);
        }
    }
    
}


