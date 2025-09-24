using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP2.Models;

namespace TP2.Controllers
{
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

        public IActionResult Create()
        {
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "NumeroBL");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Container container)
        {
            if (ModelState.IsValid)
            {
                _context.Containers.Add(container);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "NumeroBL", container.BLId);
            return View(container);
        }

        public IActionResult Edit(int id)
        {
            var container = _context.Containers.Find(id);
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "NumeroBL", container.BLId);
            return View(container);
        }

        [HttpPost]
        public IActionResult Edit(Container container)
        {
            if (ModelState.IsValid)
            {
                _context.Containers.Update(container);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.BLId = new SelectList(_context.BLs, "Id", "NumeroBL", container.BLId);
            return View(container);
        }

        public IActionResult Delete(int id)
        {
            var container = _context.Containers.Find(id);
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
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
