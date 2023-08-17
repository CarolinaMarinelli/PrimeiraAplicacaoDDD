using Carrefas.Domain.Interfaces;
using Carrefas.Domain.Interfaces.Notifications;
using Carrefas.Domain.Interfaces.Services;
using Carrefas.Domain.Models;
using Carrefas.Domain.Validations;

namespace Carrefas.Domain.Services
{
    public class ProdutoService : BaseService, IProdutoServices //conversa efetivamente com a camada de repositório e faz as regras e negócio 
    {
        private readonly IProdutoRepository _produtoRepository; // toda variável privada, precisa colocar o _ antes

        public ProdutoService(INotifier notifier, IProdutoRepository produtoRepository): base(notifier)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task AdicionarProduto(Produto produto)

        {
            //Consistencia 
            if (!RunValidation(new ProdutoValidation(), produto)) // ta passando o RunValidation, passando o Produto Validation para ver as validações que foram criadas
            {
                Notify("Produto inconsistente"); // é um método da classe base
                return;
            }

            //Condicional 
            if (_produtoRepository.BuscarProduto(p => p.Nome == produto.Nome).Result.Any()) //condicional é a consulta no banco de dados, chamando a camada de repositório
            {
                Notify("Já existe um produto cadastrado com este nome"); //se retornar verdadeiro ou falso, toma uma ação -- ANY faz retornar o verdadeiro ou falso
                return;
            } // caso não tenha, adiciona os itens no banco de dados

            //Todo novo produto deverá estar com o status de ativo
            produto.AtivarProduto();

            await _produtoRepository.AdicionarProduto(produto);

        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoRepository.Atualizar(produto); 

        }
        public async Task RemoverProduto(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
               
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

      
    }
}

//Injeção de dependencia é informar para aplicação quem esta implementando essas interfaces

////Criar Validação do produto
//if (!RunValidation(new ProdutoValidation(), produto)) return; //criando uma validação onde chama ProdutoValidation e passa como parametro o produto
//{

//// também da para retornar uma mensagem para o front se o produto for inválido

//}
//    await _produtoRepository.AdicionarProduto(produto); // se não retornar, persiste no banco
