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
� � � � � � // VERIFICA��O DE DUPLICIDADE
� � � � � � if (_context.BLs.Any(x => x.Numero == bl.Numero))
            {
� � � � � � � � // Adiciona um erro ao ModelState se o n�mero j� existir
� � � � � � � � ModelState.AddModelError("Numero", "Este n�mero de BL j� est� cadastrado.");
            }

            if (ModelState.IsValid)
            {
                _context.BLs.Add(bl);
                _context.SaveChanges();

                ViewBag.SuccessMessage = "BL registrado com sucesso!";

� � � � � � � � // LIMPEZA DO FORMUL�RIO: Retorna um objeto BL novo e vazio
� � � � � � � � return View(new BL());
            }

� � � � � � // Se a valida��o falhar, retorna com os dados para corre��o
� � � � � � return View(bl);
        }

        public IActionResult Edit(int id)
        {
            var bl = _context.BLs.Find(id);
            return View(bl);
        }

        [HttpPost]
        public IActionResult Edit(BL bl)
        {
� � � � � � // VERIFICA��O DE DUPLICIDADE (ignorando o pr�prio BL que est� sendo editado)
� � � � � � if (_context.BLs.Any(x => x.Numero == bl.Numero && x.Id != bl.Id))
            {
                ModelState.AddModelError("Numero", "Este n�mero de BL j� est� cadastrado em outro item.");
            }

            if (ModelState.IsValid)
            {
                _context.BLs.Update(bl);
                _context.SaveChanges();

� � � � � � � � // Adiciona a mensagem de sucesso ao ViewBag
� � � � � � � � ViewBag.SuccessMessage = "BL editado com sucesso!";

� � � � � � � � // Retorna para a mesma View, com os dados do 'bl' para manter os campos preenchidos
� � � � � � � � return View(bl);
            }

� � � � � � // Se a valida��o falhar, retorna com os dados para corre��o
� � � � � � return View(bl);
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
                TempData["SuccessMessage"] = "BL deletado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}