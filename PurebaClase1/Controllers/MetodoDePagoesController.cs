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
    public class MetodoDePagoesController : Controller
    {
        public IActionResult Micuenta()
        {
            return View();
        }

        private readonly ProyectoBDContext _context;

        public MetodoDePagoesController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: MetodoDePagoes
        public async Task<IActionResult> Index()
        {
            var proyectoBDContext = _context.MetodoDePagos.Include(m => m.IdUsuarioNavigation);
            return View(await proyectoBDContext.ToListAsync());
        }

        // GET: MetodoDePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MetodoDePagos == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePagos
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMetododepago == id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: MetodoDePagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetododepago,IdUsuario,NumeroDeTarjeta,Titular,Fecha,Cvv")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", metodoDePago.IdUsuario);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MetodoDePagos == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePagos.FindAsync(id);
            if (metodoDePago == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", metodoDePago.IdUsuario);
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMetododepago,IdUsuario,NumeroDeTarjeta,Titular,Fecha,Cvv")] MetodoDePago metodoDePago)
        {
            if (id != metodoDePago.IdMetododepago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoDePagoExists(metodoDePago.IdMetododepago))
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
            ViewData["IdUsuario"] = new SelectList(_context.Users, "Id", "Id", metodoDePago.IdUsuario);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MetodoDePagos == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePagos
                .Include(m => m.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdMetododepago == id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MetodoDePagos == null)
            {
                return Problem("Entity set 'ProyectoBDContext.MetodoDePagos'  is null.");
            }
            var metodoDePago = await _context.MetodoDePagos.FindAsync(id);
            if (metodoDePago != null)
            {
                _context.MetodoDePagos.Remove(metodoDePago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoDePagoExists(int id)
        {
            return (_context.MetodoDePagos?.Any(e => e.IdMetododepago == id)).GetValueOrDefault();
        }
    }
}
