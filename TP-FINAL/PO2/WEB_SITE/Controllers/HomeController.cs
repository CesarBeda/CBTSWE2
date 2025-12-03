using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Models;
using WEB_SITE.Repositories;

//Cesar Beda CB302704X

namespace WEB_SITE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IUsuarioRepository _usuarioRepository;

        public HomeController(ILogger<HomeController> logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sair()
        {
            // 1. Limpa os dados da sessão (desloga o usuário)
            HttpContext.Session.Clear();

            // 2. Redireciona para a Home (onde está o Login)
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Nome, string Senha)
        {
            var usuario = await _usuarioRepository.GetUsuarioByNome(Nome);

            if (usuario != null && usuario.Status == true && usuario.Senha == Senha)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
            
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
            
                return RedirectToAction("Index", "Produtos");
            }
            else
            {
                ViewData["ErrorMessage"] = "Nome de usu�rio ou senha inv�lidos. Verifique as credenciais.";

                return View("Index");
            }
        }
    }
}
