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
    public class AsignaturasempleadosestudiantesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public AsignaturasempleadosestudiantesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Asignaturasempleadosestudiantes
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Asignaturasempleadosestudiantes.Include(a => a.CodigoEstudianteFkNavigation).Include(a => a.IdAsignaturaEmpleadoFkNavigation).Include(a => a.IdEstadoFkNavigation).Include(a => a.IdPeriodoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Asignaturasempleadosestudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleadosestudiantes = await _context.Asignaturasempleadosestudiantes
                .Include(a => a.CodigoEstudianteFkNavigation)
                .Include(a => a.IdAsignaturaEmpleadoFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdPeriodoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaEmpleadoEstudiante == id);
            if (asignaturasempleadosestudiantes == null)
            {
                return NotFound();
            }

            return View(asignaturasempleadosestudiantes);
        }

        // GET: Asignaturasempleadosestudiantes/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["IdAsignaturaEmpleadoFk"] = new SelectList(_context.Asignaturasempleados, "IdAsignaturaEmpleado", "IdAsignaturaEmpleado");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdPeriodoFk"] = new SelectList(_context.Periodos, "IdPeriodo", "DescripcionPeriodo");
            return View();
        }

        // POST: Asignaturasempleadosestudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignaturaEmpleadoEstudiante,IdAsignaturaEmpleadoFk,CodigoEstudianteFk,IdEstadoFk,IdPeriodoFk")] Asignaturasempleadosestudiantes asignaturasempleadosestudiantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturasempleadosestudiantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", asignaturasempleadosestudiantes.CodigoEstudianteFk);
            ViewData["IdAsignaturaEmpleadoFk"] = new SelectList(_context.Asignaturasempleados, "IdAsignaturaEmpleado", "IdAsignaturaEmpleado", asignaturasempleadosestudiantes.IdAsignaturaEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleadosestudiantes.IdEstadoFk);
            ViewData["IdPeriodoFk"] = new SelectList(_context.Periodos, "IdPeriodo", "DescripcionPeriodo", asignaturasempleadosestudiantes.IdPeriodoFk);
            return View(asignaturasempleadosestudiantes);
        }

        // GET: Asignaturasempleadosestudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleadosestudiantes = await _context.Asignaturasempleadosestudiantes.FindAsync(id);
            if (asignaturasempleadosestudiantes == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", asignaturasempleadosestudiantes.CodigoEstudianteFk);
            ViewData["IdAsignaturaEmpleadoFk"] = new SelectList(_context.Asignaturasempleados, "IdAsignaturaEmpleado", "IdAsignaturaEmpleado", asignaturasempleadosestudiantes.IdAsignaturaEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleadosestudiantes.IdEstadoFk);
            ViewData["IdPeriodoFk"] = new SelectList(_context.Periodos, "IdPeriodo", "DescripcionPeriodo", asignaturasempleadosestudiantes.IdPeriodoFk);
            return View(asignaturasempleadosestudiantes);
        }

        // POST: Asignaturasempleadosestudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignaturaEmpleadoEstudiante,IdAsignaturaEmpleadoFk,CodigoEstudianteFk,IdEstadoFk,IdPeriodoFk")] Asignaturasempleadosestudiantes asignaturasempleadosestudiantes)
        {
            if (id != asignaturasempleadosestudiantes.IdAsignaturaEmpleadoEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturasempleadosestudiantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasempleadosestudiantesExists(asignaturasempleadosestudiantes.IdAsignaturaEmpleadoEstudiante))
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
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", asignaturasempleadosestudiantes.CodigoEstudianteFk);
            ViewData["IdAsignaturaEmpleadoFk"] = new SelectList(_context.Asignaturasempleados, "IdAsignaturaEmpleado", "IdAsignaturaEmpleado", asignaturasempleadosestudiantes.IdAsignaturaEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleadosestudiantes.IdEstadoFk);
            ViewData["IdPeriodoFk"] = new SelectList(_context.Periodos, "IdPeriodo", "DescripcionPeriodo", asignaturasempleadosestudiantes.IdPeriodoFk);
            return View(asignaturasempleadosestudiantes);
        }

        // GET: Asignaturasempleadosestudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleadosestudiantes = await _context.Asignaturasempleadosestudiantes
                .Include(a => a.CodigoEstudianteFkNavigation)
                .Include(a => a.IdAsignaturaEmpleadoFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdPeriodoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaEmpleadoEstudiante == id);
            if (asignaturasempleadosestudiantes == null)
            {
                return NotFound();
            }

            return View(asignaturasempleadosestudiantes);
        }

        // POST: Asignaturasempleadosestudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturasempleadosestudiantes = await _context.Asignaturasempleadosestudiantes.FindAsync(id);
            _context.Asignaturasempleadosestudiantes.Remove(asignaturasempleadosestudiantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasempleadosestudiantesExists(int id)
        {
            return _context.Asignaturasempleadosestudiantes.Any(e => e.IdAsignaturaEmpleadoEstudiante == id);
        }
    }
}
