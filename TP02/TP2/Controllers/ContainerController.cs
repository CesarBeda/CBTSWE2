using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    // A classe começa aqui
    public class ContainerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContainerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var containers = _context.Containers.Include(c => c.BL).ToList();
            return View(containers);
        }

        // --- MÉTODOS CREATE ---
        public IActionResult Create()
        {
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Container container)
        {
            if (_context.Containers.Any(x => x.Numero == container.Numero))
            {
                ModelState.AddModelError("Numero", "Este número de Container já está cadastrado.");
            }

            if (ModelState.IsValid)
            {
                _context.Containers.Add(container);
                _context.SaveChanges();
                ViewBag.SuccessMessage = "Container registrado com sucesso!";
                ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero");
                return View(new Container());
            }

            ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        // --- MÉTODOS EDIT ---
        public IActionResult Edit(int id)
        {
            var container = _context.Containers.Find(id);
            if (container == null)
            {
                return NotFound();
            }
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        [HttpPost]
        public IActionResult Edit(Container container)
        {
            if (_context.Containers.Any(x => x.Numero == container.Numero && x.Id != container.Id))
            {
                ModelState.AddModelError("Numero", "Este número de Container já está cadastrado em outro item.");
            }

            if (ModelState.IsValid)
            {
                _context.Containers.Update(container);
                _context.SaveChanges();
                ViewBag.SuccessMessage = "Container editado com sucesso!";
                ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
                return View(container);
            }

            ViewBag.BLId = new SelectList(_context.BLs, "Id", "Numero", container.BLId);
            return View(container);
        }

        // --- MÉTODOS DELETE ---
        public IActionResult Delete(int id)
        {
            var container = _context.Containers.Include(c => c.BL).FirstOrDefault(m => m.Id == id);
            if (container == null)
            {
                return NotFound();
            }
            return View(container);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var container = _context.Containers.Find(id);
            if (container != null)
            {
                _context.Containers.Remove(container);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Container deletado com sucesso!";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}