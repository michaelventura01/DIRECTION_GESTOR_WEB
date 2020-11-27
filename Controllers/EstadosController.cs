using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIRECTION_GESTOR.Models;

namespace DIRECTION_GESTOR.Controllers
{
    public class EstadosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EstadosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Estados
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Estados.Include(e => e.IdDominioEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Estados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estados = await _context.Estados
                .Include(e => e.IdDominioEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estados == null)
            {
                return NotFound();
            }

            return View(estados);
        }

        // GET: Estados/Create
        public IActionResult Create()
        {
            ViewData["IdDominioEstadoFk"] = new SelectList(_context.Dominioestados, "IdDominioEstado", "DescripcionDominioEstado");
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,DescripcionEstado,Estado,IdDominioEstadoFk")] Estados estados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDominioEstadoFk"] = new SelectList(_context.Dominioestados, "IdDominioEstado", "DescripcionDominioEstado", estados.IdDominioEstadoFk);
            return View(estados);
        }

        // GET: Estados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estados = await _context.Estados.FindAsync(id);
            if (estados == null)
            {
                return NotFound();
            }
            ViewData["IdDominioEstadoFk"] = new SelectList(_context.Dominioestados, "IdDominioEstado", "DescripcionDominioEstado", estados.IdDominioEstadoFk);
            return View(estados);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,DescripcionEstado,Estado,IdDominioEstadoFk")] Estados estados)
        {
            if (id != estados.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosExists(estados.IdEstado))
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
            ViewData["IdDominioEstadoFk"] = new SelectList(_context.Dominioestados, "IdDominioEstado", "DescripcionDominioEstado", estados.IdDominioEstadoFk);
            return View(estados);
        }

        // GET: Estados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estados = await _context.Estados
                .Include(e => e.IdDominioEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estados == null)
            {
                return NotFound();
            }

            return View(estados);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estados = await _context.Estados.FindAsync(id);
            _context.Estados.Remove(estados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosExists(int id)
        {
            return _context.Estados.Any(e => e.IdEstado == id);
        }
    }
}
