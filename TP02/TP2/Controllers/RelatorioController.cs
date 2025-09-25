using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class RelatorioController : Controller
    {
        // 1. Declara a variável para o banco de dados
        private readonly ApplicationDbContext _context;

        // 2. Cria o construtor que recebe o banco de dados
        public RelatorioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 3. Coloca o método Index DENTRO da classe
        public IActionResult Index()
        {
            var todosOsBLs = _context.BLs.Include(bl => bl.Containers).ToList();
            return View(todosOsBLs);
        }

    }
}