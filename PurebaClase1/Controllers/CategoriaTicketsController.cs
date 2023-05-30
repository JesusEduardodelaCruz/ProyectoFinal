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
    public class CategoriaTicketsController : Controller
    {
        private readonly ProyectoBDContext _context;

        public CategoriaTicketsController(ProyectoBDContext context)
        {
            _context = context;
        }

        // GET: CategoriaTickets
        public async Task<IActionResult> Index()
        {
              return _context.CategoriaTickets != null ? 
                          View(await _context.CategoriaTickets.ToListAsync()) :
                          Problem("Entity set 'ProyectoBDContext.CategoriaTickets'  is null.");
        }

        // GET: CategoriaTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriaTickets == null)
            {
                return NotFound();
            }

            var categoriaTicket = await _context.CategoriaTickets
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaTicket == null)
            {
                return NotFound();
            }

            return View(categoriaTicket);
        }

        // GET: CategoriaTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,Descripcion")] CategoriaTicket categoriaTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaTicket);
        }

        // GET: CategoriaTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriaTickets == null)
            {
                return NotFound();
            }

            var categoriaTicket = await _context.CategoriaTickets.FindAsync(id);
            if (categoriaTicket == null)
            {
                return NotFound();
            }
            return View(categoriaTicket);
        }

        // POST: CategoriaTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Descripcion")] CategoriaTicket categoriaTicket)
        {
            if (id != categoriaTicket.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaTicketExists(categoriaTicket.IdCategoria))
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
            return View(categoriaTicket);
        }

        // GET: CategoriaTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriaTickets == null)
            {
                return NotFound();
            }

            var categoriaTicket = await _context.CategoriaTickets
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaTicket == null)
            {
                return NotFound();
            }

            return View(categoriaTicket);
        }

        // POST: CategoriaTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriaTickets == null)
            {
                return Problem("Entity set 'ProyectoBDContext.CategoriaTickets'  is null.");
            }
            var categoriaTicket = await _context.CategoriaTickets.FindAsync(id);
            if (categoriaTicket != null)
            {
                _context.CategoriaTickets.Remove(categoriaTicket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaTicketExists(int id)
        {
          return (_context.CategoriaTickets?.Any(e => e.IdCategoria == id)).GetValueOrDefault();
        }
    }
}
