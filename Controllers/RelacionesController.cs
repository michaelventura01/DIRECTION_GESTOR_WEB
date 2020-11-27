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
    public class RelacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public RelacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Relaciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Relaciones.Include(r => r.IdPersonaFkNavigation).Include(r => r.IdPersonaRelacionFkNavigation).Include(r => r.IdTipoRelacionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Relaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relaciones = await _context.Relaciones
                .Include(r => r.IdPersonaFkNavigation)
                .Include(r => r.IdPersonaRelacionFkNavigation)
                .Include(r => r.IdTipoRelacionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relaciones == null)
            {
                return NotFound();
            }

            return View(relaciones);
        }

        // GET: Relaciones/Create
        public IActionResult Create()
        {
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdPersonaRelacionFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdTipoRelacionFk"] = new SelectList(_context.Tiposrelaciones, "IdTipoRelacion", "DescripcionTipoRelacion");
            return View();
        }

        // POST: Relaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRelacion,IdPersonaFk,IdPersonaRelacionFk,IdTipoRelacionFk")] Relaciones relaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaFk);
            ViewData["IdPersonaRelacionFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaRelacionFk);
            ViewData["IdTipoRelacionFk"] = new SelectList(_context.Tiposrelaciones, "IdTipoRelacion", "DescripcionTipoRelacion", relaciones.IdTipoRelacionFk);
            return View(relaciones);
        }

        // GET: Relaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relaciones = await _context.Relaciones.FindAsync(id);
            if (relaciones == null)
            {
                return NotFound();
            }
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaFk);
            ViewData["IdPersonaRelacionFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaRelacionFk);
            ViewData["IdTipoRelacionFk"] = new SelectList(_context.Tiposrelaciones, "IdTipoRelacion", "DescripcionTipoRelacion", relaciones.IdTipoRelacionFk);
            return View(relaciones);
        }

        // POST: Relaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRelacion,IdPersonaFk,IdPersonaRelacionFk,IdTipoRelacionFk")] Relaciones relaciones)
        {
            if (id != relaciones.IdRelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelacionesExists(relaciones.IdRelacion))
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
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaFk);
            ViewData["IdPersonaRelacionFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", relaciones.IdPersonaRelacionFk);
            ViewData["IdTipoRelacionFk"] = new SelectList(_context.Tiposrelaciones, "IdTipoRelacion", "DescripcionTipoRelacion", relaciones.IdTipoRelacionFk);
            return View(relaciones);
        }

        // GET: Relaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relaciones = await _context.Relaciones
                .Include(r => r.IdPersonaFkNavigation)
                .Include(r => r.IdPersonaRelacionFkNavigation)
                .Include(r => r.IdTipoRelacionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdRelacion == id);
            if (relaciones == null)
            {
                return NotFound();
            }

            return View(relaciones);
        }

        // POST: Relaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relaciones = await _context.Relaciones.FindAsync(id);
            _context.Relaciones.Remove(relaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelacionesExists(int id)
        {
            return _context.Relaciones.Any(e => e.IdRelacion == id);
        }
    }
}
