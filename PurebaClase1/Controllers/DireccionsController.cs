using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurebaClase1.Models.dbModels;

namespace PurebaClase1.Controllers
{
    [Authorize]
    public class DireccionsController : Controller
    {
        
        public IActionResult Micuenta()
        {
            return View();
        }
        private readonly ProyectoBDContext _context;

        public DireccionsController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: Direccions
        public async Task<IActionResult> Index()
        {
            var proyectoBDContext = _context.Direccions.Include(d => d.IdUsuarioNavigation);
            return View(await proyectoBDContext.ToListAsync());
        }

        // GET: Direccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direccions/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Direccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccion,IdUsuario,Colonia,Calle,NoExt,CodigoPostal")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", direccion.IdUsuario);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", direccion.IdUsuario);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccion,IdUsuario,Colonia,Calle,NoExt,CodigoPostal")] Direccion direccion)
        {
            if (id != direccion.IdDireccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.IdDireccion))
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", direccion.IdUsuario);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Direccions == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .Include(d => d.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Direccions == null)
            {
                return Problem("Entity set 'ProyectoBDContext.Direccions'  is null.");
            }
            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion != null)
            {
                _context.Direccions.Remove(direccion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
          return (_context.Direccions?.Any(e => e.IdDireccion == id)).GetValueOrDefault();
        }
    }
}
