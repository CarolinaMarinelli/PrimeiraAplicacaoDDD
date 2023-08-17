using Carrefas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrefas.Domain.Interfaces.Services
{
    public interface IProdutoServices : IDisposable
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task RemoverProduto(Guid id);

     
    }
}
