using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models;
using PurebaClase1.Models.dbModels;

namespace PurebaClase1.Controllers
{
    [Authorize(Roles = "Admin") ]
    public class RopasController : Controller
    {
        public IActionResult Ropadmin()
        {
            return View();
        }
        private readonly ProyectoBDContext _context;

        public RopasController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: Ropas
        public async Task<IActionResult> Index()
        {
            var proyectoBDContext = _context.Ropas.Include(r => r.IdCategoriaNavigation).Include(r => r.IdColorNavigation);
            return View(await proyectoBDContext.ToListAsync());
        }

        // GET: Ropas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas
                .Include(r => r.IdCategoriaNavigation)
                .Include(r => r.IdColorNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropa == null)
            {
                return NotFound();
            }

            return View(ropa);
        }

        // GET: Ropas/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaRopas, "IdCategoria", "IdCategoria");
            ViewData["IdColor"] = new SelectList(_context.Colors, "IdColor", "IdColor");
            return View();
        }

        // POST: Ropas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRopa,IdColor,IdCategoria,Imagen,Titulo,Descripcion")] RopaHR ropa)
        {
            if (ModelState.IsValid)
            {

                Ropa ropa1 = new Ropa
                {

                    IdRopa = ropa.IdRopa,
                    IdColor = ropa.IdColor,
                    IdCategoria = ropa.IdCategoria,
                    Imagen = ropa.Imagen,
                    Titulo = ropa.Titulo,
                    Descripcion = ropa.Descripcion
                };

                _context.Ropas.Add(ropa1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaRopas, "IdCategoria", "IdCategoria", ropa.IdCategoria);
            ViewData["IdColor"] = new SelectList(_context.Colors, "IdColor", "IdColor", ropa.IdColor);
            return View(ropa);
        }

        // GET: Ropas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas.FindAsync(id);
            if (ropa == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaRopas, "IdCategoria", "IdCategoria", ropa.IdCategoria);
            ViewData["IdColor"] = new SelectList(_context.Colors, "IdColor", "IdColor", ropa.IdColor);
            return View(ropa);
        }

        // POST: Ropas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRopa,IdColor,IdCategoria,Imagen,Titulo,Descripcion")] Ropa ropa)
        {
            if (id != ropa.IdRopa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ropa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RopaExists(ropa.IdRopa))
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
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaRopas, "IdCategoria", "IdCategoria", ropa.IdCategoria);
            ViewData["IdColor"] = new SelectList(_context.Colors, "IdColor", "IdColor", ropa.IdColor);
            return View(ropa);
        }

        // GET: Ropas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ropas == null)
            {
                return NotFound();
            }

            var ropa = await _context.Ropas
                .Include(r => r.IdCategoriaNavigation)
                .Include(r => r.IdColorNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropa == null)
            {
                return NotFound();
            }

            return View(ropa);
        }

        // POST: Ropas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ropas == null)
            {
                return Problem("Entity set 'ProyectoBDContext.Ropas'  is null.");
            }
            var ropa = await _context.Ropas.FindAsync(id);
            if (ropa != null)
            {
                _context.Ropas.Remove(ropa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RopaExists(int id)
        {
          return (_context.Ropas?.Any(e => e.IdRopa == id)).GetValueOrDefault();
        }
    }
}
