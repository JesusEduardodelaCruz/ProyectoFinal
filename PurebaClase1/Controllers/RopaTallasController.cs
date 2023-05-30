using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models;
using PurebaClase1.Models.dbModels;

namespace PurebaClase1.Controllers
{
    public class RopaTallasController : Controller
    {
        public IActionResult Ropadmin()
        {
            return View();
        }
        private readonly ProyectoBDContext _context;

        public RopaTallasController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: RopaTallas
        public async Task<IActionResult> Index()
        {
            var proyectoBDContext = _context.RopaTallas.Include(r => r.IdRopaNavigation).Include(r => r.IdTallaNavigation);
            return View(await proyectoBDContext.ToListAsync());
        }

        // GET: RopaTallas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RopaTallas == null)
            {
                return NotFound();
            }

            var ropaTalla = await _context.RopaTallas
                .Include(r => r.IdRopaNavigation)
                .Include(r => r.IdTallaNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropaTalla == null)
            {
                return NotFound();
            }

            return View(ropaTalla);
        }

        // GET: RopaTallas/Create
        public IActionResult Create()
        {
            ViewData["IdRopa"] = new SelectList(_context.Ropas, "IdRopa", "IdRopa");
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "IdTalla");
            return View();
        }

        // POST: RopaTallas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRopa,IdTalla,Cantidad")] RopaTallasHR ropaTalla)
        {
            if (ModelState.IsValid)
            {
                RopaTalla ropaTalla1 = new RopaTalla
                { 
                    IdRopa = ropaTalla.IdRopa,
                    IdTalla = ropaTalla.IdTalla,
                    Cantidad = ropaTalla.Cantidad
                };
                _context.Add(ropaTalla1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRopa"] = new SelectList(_context.Ropas, "IdRopa", "IdRopa", ropaTalla.IdRopa);
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "IdTalla", ropaTalla.IdTalla);
            return View(ropaTalla);
        }

        // GET: RopaTallas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RopaTallas == null)
            {
                return NotFound();
            }

            var ropaTalla = await _context.RopaTallas.FindAsync(id);
            if (ropaTalla == null)
            {
                return NotFound();
            }
            ViewData["IdRopa"] = new SelectList(_context.Ropas, "IdRopa", "IdRopa", ropaTalla.IdRopa);
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "IdTalla", ropaTalla.IdTalla);
            return View(ropaTalla);
        }

        // POST: RopaTallas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRopa,IdTalla,Cantidad")] RopaTalla ropaTalla)
        {
            if (id != ropaTalla.IdRopa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ropaTalla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RopaTallaExists(ropaTalla.IdRopa))
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
            ViewData["IdRopa"] = new SelectList(_context.Ropas, "IdRopa", "IdRopa", ropaTalla.IdRopa);
            ViewData["IdTalla"] = new SelectList(_context.Tallas, "IdTalla", "IdTalla", ropaTalla.IdTalla);
            return View(ropaTalla);
        }

        // GET: RopaTallas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RopaTallas == null)
            {
                return NotFound();
            }

            var ropaTalla = await _context.RopaTallas
                .Include(r => r.IdRopaNavigation)
                .Include(r => r.IdTallaNavigation)
                .FirstOrDefaultAsync(m => m.IdRopa == id);
            if (ropaTalla == null)
            {
                return NotFound();
            }

            return View(ropaTalla);
        }

        // POST: RopaTallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RopaTallas == null)
            {
                return Problem("Entity set 'ProyectoBDContext.RopaTallas'  is null.");
            }
            var ropaTalla = await _context.RopaTallas.FindAsync(id);
            if (ropaTalla != null)
            {
                _context.RopaTallas.Remove(ropaTalla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RopaTallaExists(int id)
        {
          return (_context.RopaTallas?.Any(e => e.IdRopa == id)).GetValueOrDefault();
        }
    }
}
