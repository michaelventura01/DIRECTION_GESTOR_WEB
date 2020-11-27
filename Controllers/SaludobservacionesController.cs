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
    public class SaludobservacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public SaludobservacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Saludobservaciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Saludobservaciones.Include(s => s.IdEstadoFkNavigation).Include(s => s.IdInstitucionFkNavigation).Include(s => s.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Saludobservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saludobservaciones = await _context.Saludobservaciones
                .Include(s => s.IdEstadoFkNavigation)
                .Include(s => s.IdInstitucionFkNavigation)
                .Include(s => s.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdSaludObservacion == id);
            if (saludobservaciones == null)
            {
                return NotFound();
            }

            return View(saludobservaciones);
        }

        // GET: Saludobservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            return View();
        }

        // POST: Saludobservaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSaludObservacion,DescripcionSaludObservacion,FechaSaludObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Saludobservaciones saludobservaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saludobservaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", saludobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", saludobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", saludobservaciones.IdPersonaFk);
            return View(saludobservaciones);
        }

        // GET: Saludobservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saludobservaciones = await _context.Saludobservaciones.FindAsync(id);
            if (saludobservaciones == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", saludobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", saludobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", saludobservaciones.IdPersonaFk);
            return View(saludobservaciones);
        }

        // POST: Saludobservaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSaludObservacion,DescripcionSaludObservacion,FechaSaludObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Saludobservaciones saludobservaciones)
        {
            if (id != saludobservaciones.IdSaludObservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saludobservaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaludobservacionesExists(saludobservaciones.IdSaludObservacion))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", saludobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", saludobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", saludobservaciones.IdPersonaFk);
            return View(saludobservaciones);
        }

        // GET: Saludobservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saludobservaciones = await _context.Saludobservaciones
                .Include(s => s.IdEstadoFkNavigation)
                .Include(s => s.IdInstitucionFkNavigation)
                .Include(s => s.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdSaludObservacion == id);
            if (saludobservaciones == null)
            {
                return NotFound();
            }

            return View(saludobservaciones);
        }

        // POST: Saludobservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saludobservaciones = await _context.Saludobservaciones.FindAsync(id);
            _context.Saludobservaciones.Remove(saludobservaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaludobservacionesExists(int id)
        {
            return _context.Saludobservaciones.Any(e => e.IdSaludObservacion == id);
        }
    }
}
