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
    public class CircunscripcionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public CircunscripcionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Circunscripciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Circunscripciones.Include(c => c.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Circunscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circunscripciones = await _context.Circunscripciones
                .Include(c => c.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCircunscripcion == id);
            if (circunscripciones == null)
            {
                return NotFound();
            }

            return View(circunscripciones);
        }

        // GET: Circunscripciones/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Circunscripciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCircunscripcion,DescripcionCircunscripcion,IdEstadoFk")] Circunscripciones circunscripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(circunscripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", circunscripciones.IdEstadoFk);
            return View(circunscripciones);
        }

        // GET: Circunscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circunscripciones = await _context.Circunscripciones.FindAsync(id);
            if (circunscripciones == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", circunscripciones.IdEstadoFk);
            return View(circunscripciones);
        }

        // POST: Circunscripciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCircunscripcion,DescripcionCircunscripcion,IdEstadoFk")] Circunscripciones circunscripciones)
        {
            if (id != circunscripciones.IdCircunscripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circunscripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircunscripcionesExists(circunscripciones.IdCircunscripcion))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", circunscripciones.IdEstadoFk);
            return View(circunscripciones);
        }

        // GET: Circunscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var circunscripciones = await _context.Circunscripciones
                .Include(c => c.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCircunscripcion == id);
            if (circunscripciones == null)
            {
                return NotFound();
            }

            return View(circunscripciones);
        }

        // POST: Circunscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circunscripciones = await _context.Circunscripciones.FindAsync(id);
            _context.Circunscripciones.Remove(circunscripciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircunscripcionesExists(int id)
        {
            return _context.Circunscripciones.Any(e => e.IdCircunscripcion == id);
        }
    }
}
