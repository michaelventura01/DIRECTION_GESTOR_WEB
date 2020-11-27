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
    public class EstudiantesinstitucionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EstudiantesinstitucionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Estudiantesinstituciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Estudiantesinstituciones.Include(e => e.CodigoEstudianteFkNavigation).Include(e => e.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Estudiantesinstituciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesinstituciones = await _context.Estudiantesinstituciones
                .Include(e => e.CodigoEstudianteFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoInstitucion == id);
            if (estudiantesinstituciones == null)
            {
                return NotFound();
            }

            return View(estudiantesinstituciones);
        }

        // GET: Estudiantesinstituciones/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Estudiantesinstituciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleadoInstitucion,CodigoEstudianteFk,FechaInicio,IdInstitucionFk")] Estudiantesinstituciones estudiantesinstituciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantesinstituciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantesinstituciones.CodigoEstudianteFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", estudiantesinstituciones.IdInstitucionFk);
            return View(estudiantesinstituciones);
        }

        // GET: Estudiantesinstituciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesinstituciones = await _context.Estudiantesinstituciones.FindAsync(id);
            if (estudiantesinstituciones == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantesinstituciones.CodigoEstudianteFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", estudiantesinstituciones.IdInstitucionFk);
            return View(estudiantesinstituciones);
        }

        // POST: Estudiantesinstituciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleadoInstitucion,CodigoEstudianteFk,FechaInicio,IdInstitucionFk")] Estudiantesinstituciones estudiantesinstituciones)
        {
            if (id != estudiantesinstituciones.IdEmpleadoInstitucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantesinstituciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantesinstitucionesExists(estudiantesinstituciones.IdEmpleadoInstitucion))
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
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantesinstituciones.CodigoEstudianteFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", estudiantesinstituciones.IdInstitucionFk);
            return View(estudiantesinstituciones);
        }

        // GET: Estudiantesinstituciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantesinstituciones = await _context.Estudiantesinstituciones
                .Include(e => e.CodigoEstudianteFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoInstitucion == id);
            if (estudiantesinstituciones == null)
            {
                return NotFound();
            }

            return View(estudiantesinstituciones);
        }

        // POST: Estudiantesinstituciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantesinstituciones = await _context.Estudiantesinstituciones.FindAsync(id);
            _context.Estudiantesinstituciones.Remove(estudiantesinstituciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantesinstitucionesExists(int id)
        {
            return _context.Estudiantesinstituciones.Any(e => e.IdEmpleadoInstitucion == id);
        }
    }
}
