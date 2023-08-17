using Carrefas.Application.Interfaces;
using Carrefas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carrefas.Site.Controllers
{
    public class ProdutoControllercs : Controller
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutoControllercs(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        public IActionResult CadastrarProduto(ProdutoViewModel produtoViewModel)
        {
         _produtoApplicationService.AdicionarProduto(produtoViewModel);

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
