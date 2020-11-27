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
    public class ResponsabilidadobservacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public ResponsabilidadobservacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Responsabilidadobservaciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Responsabilidadobservaciones.Include(r => r.IdEstadoFkNavigation).Include(r => r.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Responsabilidadobservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsabilidadobservaciones = await _context.Responsabilidadobservaciones
                .Include(r => r.IdEstadoFkNavigation)
                .Include(r => r.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdResponsabilidadObservacion == id);
            if (responsabilidadobservaciones == null)
            {
                return NotFound();
            }

            return View(responsabilidadobservaciones);
        }

        // GET: Responsabilidadobservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            return View();
        }

        // POST: Responsabilidadobservaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResponsabilidadObservacion,DescripcionResponsabilidadObservacion,FechaResponsabilidadObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Responsabilidadobservaciones responsabilidadobservaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsabilidadobservaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", responsabilidadobservaciones.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", responsabilidadobservaciones.IdPersonaFk);
            return View(responsabilidadobservaciones);
        }

        // GET: Responsabilidadobservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsabilidadobservaciones = await _context.Responsabilidadobservaciones.FindAsync(id);
            if (responsabilidadobservaciones == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", responsabilidadobservaciones.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", responsabilidadobservaciones.IdPersonaFk);
            return View(responsabilidadobservaciones);
        }

        // POST: Responsabilidadobservaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResponsabilidadObservacion,DescripcionResponsabilidadObservacion,FechaResponsabilidadObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Responsabilidadobservaciones responsabilidadobservaciones)
        {
            if (id != responsabilidadobservaciones.IdResponsabilidadObservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsabilidadobservaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsabilidadobservacionesExists(responsabilidadobservaciones.IdResponsabilidadObservacion))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", responsabilidadobservaciones.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", responsabilidadobservaciones.IdPersonaFk);
            return View(responsabilidadobservaciones);
        }

        // GET: Responsabilidadobservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsabilidadobservaciones = await _context.Responsabilidadobservaciones
                .Include(r => r.IdEstadoFkNavigation)
                .Include(r => r.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdResponsabilidadObservacion == id);
            if (responsabilidadobservaciones == null)
            {
                return NotFound();
            }

            return View(responsabilidadobservaciones);
        }

        // POST: Responsabilidadobservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsabilidadobservaciones = await _context.Responsabilidadobservaciones.FindAsync(id);
            _context.Responsabilidadobservaciones.Remove(responsabilidadobservaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsabilidadobservacionesExists(int id)
        {
            return _context.Responsabilidadobservaciones.Any(e => e.IdResponsabilidadObservacion == id);
        }
    }
}
