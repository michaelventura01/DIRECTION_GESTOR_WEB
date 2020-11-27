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
    public class CalificacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public CalificacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Calificaciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Calificaciones.Include(c => c.IdAsignaturaEmpleadoEstudianteFkNavigation).Include(c => c.IdEstadoFkNavigation).Include(c => c.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Calificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.Calificaciones
                .Include(c => c.IdAsignaturaEmpleadoEstudianteFkNavigation)
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            return View(calificaciones);
        }

        // GET: Calificaciones/Create
        public IActionResult Create()
        {
            ViewData["IdAsignaturaEmpleadoEstudianteFk"] = new SelectList(_context.Asignaturasempleadosestudiantes, "IdAsignaturaEmpleadoEstudiante", "CodigoEstudianteFk");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCalificacion,Calificacion,IdAsignaturaEmpleadoEstudianteFk,IdEstadoFk,FechaCalificacion,IdInstitucionFk")] Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calificaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignaturaEmpleadoEstudianteFk"] = new SelectList(_context.Asignaturasempleadosestudiantes, "IdAsignaturaEmpleadoEstudiante", "CodigoEstudianteFk", calificaciones.IdAsignaturaEmpleadoEstudianteFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", calificaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", calificaciones.IdInstitucionFk);
            return View(calificaciones);
        }

        // GET: Calificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.Calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }
            ViewData["IdAsignaturaEmpleadoEstudianteFk"] = new SelectList(_context.Asignaturasempleadosestudiantes, "IdAsignaturaEmpleadoEstudiante", "CodigoEstudianteFk", calificaciones.IdAsignaturaEmpleadoEstudianteFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", calificaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", calificaciones.IdInstitucionFk);
            return View(calificaciones);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCalificacion,Calificacion,IdAsignaturaEmpleadoEstudianteFk,IdEstadoFk,FechaCalificacion,IdInstitucionFk")] Calificaciones calificaciones)
        {
            if (id != calificaciones.IdCalificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calificaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalificacionesExists(calificaciones.IdCalificacion))
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
            ViewData["IdAsignaturaEmpleadoEstudianteFk"] = new SelectList(_context.Asignaturasempleadosestudiantes, "IdAsignaturaEmpleadoEstudiante", "CodigoEstudianteFk", calificaciones.IdAsignaturaEmpleadoEstudianteFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", calificaciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", calificaciones.IdInstitucionFk);
            return View(calificaciones);
        }

        // GET: Calificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificaciones = await _context.Calificaciones
                .Include(c => c.IdAsignaturaEmpleadoEstudianteFkNavigation)
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCalificacion == id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            return View(calificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calificaciones = await _context.Calificaciones.FindAsync(id);
            _context.Calificaciones.Remove(calificaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalificacionesExists(int id)
        {
            return _context.Calificaciones.Any(e => e.IdCalificacion == id);
        }
    }
}
