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
    public class ConductaobservacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public ConductaobservacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Conductaobservaciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Conductaobservaciones.Include(c => c.IdEstadoFkNavigation).Include(c => c.IdInstitucionFkNavigation).Include(c => c.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Conductaobservaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductaobservaciones = await _context.Conductaobservaciones
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .Include(c => c.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdConductaObservacion == id);
            if (conductaobservaciones == null)
            {
                return NotFound();
            }

            return View(conductaobservaciones);
        }

        // GET: Conductaobservaciones/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", "ApellidoPersonas");
            return View();
        }

        // POST: Conductaobservaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConductaObservacion,DescripcionConductaObservacion,FechaConductaObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Conductaobservaciones conductaobservaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductaobservaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", conductaobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", conductaobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", conductaobservaciones.IdPersonaFk);
            return View(conductaobservaciones);
        }

        // GET: Conductaobservaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductaobservaciones = await _context.Conductaobservaciones.FindAsync(id);
            if (conductaobservaciones == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", conductaobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", conductaobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", conductaobservaciones.IdPersonaFk);
            return View(conductaobservaciones);
        }

        // POST: Conductaobservaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConductaObservacion,DescripcionConductaObservacion,FechaConductaObservacion,IdEstadoFk,IdPersonaFk,IdInstitucionFk")] Conductaobservaciones conductaobservaciones)
        {
            if (id != conductaobservaciones.IdConductaObservacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductaobservaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductaobservacionesExists(conductaobservaciones.IdConductaObservacion))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", conductaobservaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", conductaobservaciones.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", conductaobservaciones.IdPersonaFk);
            return View(conductaobservaciones);
        }

        // GET: Conductaobservaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductaobservaciones = await _context.Conductaobservaciones
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .Include(c => c.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdConductaObservacion == id);
            if (conductaobservaciones == null)
            {
                return NotFound();
            }

            return View(conductaobservaciones);
        }

        // POST: Conductaobservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conductaobservaciones = await _context.Conductaobservaciones.FindAsync(id);
            _context.Conductaobservaciones.Remove(conductaobservaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductaobservacionesExists(int id)
        {
            return _context.Conductaobservaciones.Any(e => e.IdConductaObservacion == id);
        }
    }
}
