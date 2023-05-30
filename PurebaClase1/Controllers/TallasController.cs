using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models.dbModels;

namespace PurebaClase1.Controllers
{
    public class TallasController : Controller
    {
        public IActionResult Ropadmin()
        {
            return View();
        }
        private readonly ProyectoBDContext _context;

        public TallasController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: Tallas
        public async Task<IActionResult> Index()
        {
              return _context.Tallas != null ? 
                          View(await _context.Tallas.ToListAsync()) :
                          Problem("Entity set 'ProyectoBDContext.Tallas'  is null.");
        }

        // GET: Tallas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .FirstOrDefaultAsync(m => m.IdTalla == id);
            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // GET: Tallas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tallas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTalla,Descripcion")] Talla talla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(talla);
        }

        // GET: Tallas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas.FindAsync(id);
            if (talla == null)
            {
                return NotFound();
            }
            return View(talla);
        }

        // POST: Tallas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTalla,Descripcion")] Talla talla)
        {
            if (id != talla.IdTalla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallaExists(talla.IdTalla))
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
            return View(talla);
        }

        // GET: Tallas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tallas == null)
            {
                return NotFound();
            }

            var talla = await _context.Tallas
                .FirstOrDefaultAsync(m => m.IdTalla == id);
            if (talla == null)
            {
                return NotFound();
            }

            return View(talla);
        }

        // POST: Tallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tallas == null)
            {
                return Problem("Entity set 'ProyectoBDContext.Tallas'  is null.");
            }
            var talla = await _context.Tallas.FindAsync(id);
            if (talla != null)
            {
                _context.Tallas.Remove(talla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TallaExists(int id)
        {
          return (_context.Tallas?.Any(e => e.IdTalla == id)).GetValueOrDefault();
        }
    }
}
