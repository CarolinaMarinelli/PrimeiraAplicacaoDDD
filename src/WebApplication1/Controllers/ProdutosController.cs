using Carrefas.Application.Interfaces;
using Carrefas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        public ProdutosController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        public async Task<IActionResult> Index() //para devovler todos os produtos cadastrados dentro do banco e dados
        {
            return await _produtoApplicationService.ListarTodosProdutos() != null ?
                        View(await _produtoApplicationService.ListarTodosProdutos()) :
                        Problem("Entity set 'Contexto.Produtos'  is null.");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoApplicationService.AdicionarProduto(produtoViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(produtoViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var produto = await _produtoApplicationService.BuscarProdutoPeloId(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produto = await _produtoApplicationService.BuscarProdutoPeloId(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoApplicationService.AtualizarProduto(produtoViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await _produtoApplicationService.BuscarProdutoPeloId(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _produtoApplicationService.BuscarProdutoPeloId(id);
            if (produto != null)
                await _produtoApplicationService.RemoverProduto(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
