using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models.dbModels;

namespace PurebaClase1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriaRopasController : Controller
    {
        public IActionResult Ropadmin()
        {
            return View();
        }
        private readonly ProyectoBDContext _context;

        public CategoriaRopasController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: CategoriaRopas
        public async Task<IActionResult> Index()
        {
              return _context.CategoriaRopas != null ? 
                          View(await _context.CategoriaRopas.ToListAsync()) :
                          Problem("Entity set 'ProyectoBDContext.CategoriaRopas'  is null.");
        }

        // GET: CategoriaRopas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriaRopas == null)
            {
                return NotFound();
            }

            var categoriaRopa = await _context.CategoriaRopas
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaRopa == null)
            {
                return NotFound();
            }

            return View(categoriaRopa);
        }

        // GET: CategoriaRopas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaRopas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,Descripcion")] CategoriaRopa categoriaRopa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaRopa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaRopa);
        }

        // GET: CategoriaRopas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriaRopas == null)
            {
                return NotFound();
            }

            var categoriaRopa = await _context.CategoriaRopas.FindAsync(id);
            if (categoriaRopa == null)
            {
                return NotFound();
            }
            return View(categoriaRopa);
        }

        // POST: CategoriaRopas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Descripcion")] CategoriaRopa categoriaRopa)
        {
            if (id != categoriaRopa.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaRopa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaRopaExists(categoriaRopa.IdCategoria))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaRopa);
        }

        // GET: CategoriaRopas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriaRopas == null)
            {
                return NotFound();
            }

            var categoriaRopa = await _context.CategoriaRopas
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaRopa == null)
            {
                return NotFound();
            }

            return View(categoriaRopa);
        }

        // POST: CategoriaRopas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriaRopas == null)
            {
                return Problem("Entity set 'ProyectoBDContext.CategoriaRopas'  is null.");
            }
            var categoriaRopa = await _context.CategoriaRopas.FindAsync(id);
            if (categoriaRopa != null)
            {
                _context.CategoriaRopas.Remove(categoriaRopa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaRopaExists(int id)
        {
          return (_context.CategoriaRopas?.Any(e => e.IdCategoria == id)).GetValueOrDefault();
        }
    }
}
