using Microsoft.AspNetCore.Mvc;
using Models;
using WEB_SITE.Repositories;

//Cesar Beda CB302704X

namespace WEB_SITE.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            Produto[] produtos = await _produtoRepository.GetAllAsync();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (!usuarioId.HasValue || usuarioId.Value == 0)
                return RedirectToAction("Index", "Home");


            produto.IdUsuarioCadastro = usuarioId.Value;

            ModelState.Remove("Id");
            ModelState.Remove("IdUsuarioUpdate");
            ModelState.Remove("IdUsuarioCadastro");

            if (ModelState.IsValid)
            {
                await _produtoRepository.AddAsync(produto, usuarioId.Value);
                return RedirectToAction("Index", "Produtos");
            }

            return View(produto);
        }

        public async Task<IActionResult> Editar(int id)
        {
            Produto produto = await _produtoRepository.GetByIdAsync(id);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Produto produto)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (!usuarioId.HasValue || usuarioId.Value == 0)
                return RedirectToAction("Index", "Home");

            produto.IdUsuarioUpdate = usuarioId.Value;
            ModelState.Remove("IdUsuarioCadastro");
            ModelState.Remove("IdUsuarioUpdate");

            if (ModelState.IsValid)
            {
                await _produtoRepository.UpdateAsync(produto, usuarioId.Value);
                return RedirectToAction("Index", "Produtos");
            }

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (!usuarioId.HasValue || usuarioId.Value == 0)
                return RedirectToAction("Index", "Home");

            await _produtoRepository.DeleteAsync(id);
            return RedirectToAction("Index", "Produtos");
        }
    }
}
