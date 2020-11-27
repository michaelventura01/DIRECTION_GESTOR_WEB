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
    public class ActanacimientoesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public ActanacimientoesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Actanacimientoes
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Actanacimiento.Include(a => a.IdCircunscripcionFkNavigation).Include(a => a.IdEstadoFkNavigation).Include(a => a.IdInstitucionFkNavigation).Include(a => a.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Actanacimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actanacimiento = await _context.Actanacimiento
                .Include(a => a.IdCircunscripcionFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .Include(a => a.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdActaNacimiento == id);
            if (actanacimiento == null)
            {
                return NotFound();
            }

            return View(actanacimiento);
        }

        // GET: Actanacimientoes/Create
        public IActionResult Create()
        {
            ViewData["IdCircunscripcionFk"] = new SelectList(_context.Circunscripciones, "IdCircunscripcion", "DescripcionCircunscripcion");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas","ApellidoPersonas");
            return View();
        }

        // POST: Actanacimientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActaNacimiento,FolioActaNacimiento,AnioActaNacimiento,LibroActaNacimiento,NumeroActaNacimiento,IdPersonaFk,IdEstadoFk,IdCircunscripcionFk,IdInstitucionFk")] Actanacimiento actanacimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actanacimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCircunscripcionFk"] = new SelectList(_context.Circunscripciones, "IdCircunscripcion", "DescripcionCircunscripcion", actanacimiento.IdCircunscripcionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", actanacimiento.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", actanacimiento.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", actanacimiento.IdPersonaFk);
            return View(actanacimiento);
        }

        // aca GET: Actanacimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actanacimiento = await _context.Actanacimiento.FindAsync(id);
            if (actanacimiento == null)
            {
                return NotFound();
            }
            ViewData["IdCircunscripcionFk"] = new SelectList(_context.Circunscripciones, "IdCircunscripcion", "DescripcionCircunscripcion", actanacimiento.IdCircunscripcionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", actanacimiento.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", actanacimiento.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", actanacimiento.IdPersonaFk);
            return View(actanacimiento);
        }

        // POST: Actanacimientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActaNacimiento,FolioActaNacimiento,AnioActaNacimiento,LibroActaNacimiento,NumeroActaNacimiento,IdPersonaFk,IdEstadoFk,IdCircunscripcionFk,IdInstitucionFk")] Actanacimiento actanacimiento)
        {
            if (id != actanacimiento.IdActaNacimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actanacimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActanacimientoExists(actanacimiento.IdActaNacimiento))
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
            ViewData["IdCircunscripcionFk"] = new SelectList(_context.Circunscripciones, "IdCircunscripcion", "DescripcionCircunscripcion", actanacimiento.IdCircunscripcionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", actanacimiento.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", actanacimiento.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", actanacimiento.IdPersonaFk);
            return View(actanacimiento);
        }

        // GET: Actanacimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actanacimiento = await _context.Actanacimiento
                .Include(a => a.IdCircunscripcionFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .Include(a => a.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdActaNacimiento == id);
            if (actanacimiento == null)
            {
                return NotFound();
            }

            return View(actanacimiento);
        }

        // POST: Actanacimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actanacimiento = await _context.Actanacimiento.FindAsync(id);
            _context.Actanacimiento.Remove(actanacimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActanacimientoExists(int id)
        {
            return _context.Actanacimiento.Any(e => e.IdActaNacimiento == id);
        }
    }
}
