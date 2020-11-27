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
    public class EstudiantesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EstudiantesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Estudiantes.Include(e => e.IdEstadoFkNavigation).Include(e => e.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiante == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", "ApellidoPersonas");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEstudiante,FechaInicioEstudiante,IdPersonaFk,IdEstadoFk,IdInstitucionFk")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", estudiantes.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", estudiantes.IdPersonaFk);
            return View(estudiantes);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes.FindAsync(id);
            if (estudiantes == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", estudiantes.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", estudiantes.IdPersonaFk);
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoEstudiante,FechaInicioEstudiante,IdPersonaFk,IdEstadoFk,IdInstitucionFk")] Estudiantes estudiantes)
        {
            if (id != estudiantes.CodigoEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesExists(estudiantes.CodigoEstudiante))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", estudiantes.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", estudiantes.IdPersonaFk);
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantes = await _context.Estudiantes
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEstudiante == id);
            if (estudiantes == null)
            {
                return NotFound();
            }

            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estudiantes = await _context.Estudiantes.FindAsync(id);
            _context.Estudiantes.Remove(estudiantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesExists(string id)
        {
            return _context.Estudiantes.Any(e => e.CodigoEstudiante == id);
        }
    }
}
