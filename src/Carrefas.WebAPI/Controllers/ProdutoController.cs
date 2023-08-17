using Carrefas.Application.Interfaces;
using Carrefas.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carrefas.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }
        [HttpPost]
        public async Task<ActionResult> AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid) // verificar se o produto é válido com base nas datas annotation
            await _produtoApplicationService.AdicionarProduto(produtoViewModel);

            return Ok();
        }

    }
}

//ActionResult é uma IDE do próprio .Net. Vai receber do frontend o produto viewmodel