using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP2.Models;

namespace TP2.Controllers
{
    public class BLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BLController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bls = _context.BLs.Include(b => b.Containers).ToList();
            return View(bls);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.BLs.Add(bl);
                _context.SaveChanges();

                // 1. Adiciona a mensagem de sucesso ao ViewBag
                ViewBag.SuccessMessage = "BL registrado com sucesso!";

                // 2. Limpa o modelo para que o formulário apareça vazio
                return View(new BL());
            }
            // Se a validação falhar, retorna para a view com os dados preenchidos para correção
            return View(bl);
        }

        public IActionResult Edit(int id)
        {
            var bl = _context.BLs.Find(id);
            return View(bl);
        }

        [HttpPost]
        public IActionResult Edit(BL bl)
        {
            if (ModelState.IsValid)
            {
                _context.BLs.Update(bl);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }

        public IActionResult Delete(int id)
        {
            var bl = _context.BLs.Find(id);
            return View(bl);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var bl = _context.BLs.Find(id);
            if (bl != null)
            {
                _context.BLs.Remove(bl);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
