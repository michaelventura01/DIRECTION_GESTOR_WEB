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
    public class EstudiantescursosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EstudiantescursosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Estudiantescursos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Estudiantescursos.Include(e => e.CodigoEstudianteFkNavigation).Include(e => e.IdCursoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Estudiantescursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantescursos = await _context.Estudiantescursos
                .Include(e => e.CodigoEstudianteFkNavigation)
                .Include(e => e.IdCursoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudianteCurso == id);
            if (estudiantescursos == null)
            {
                return NotFound();
            }

            return View(estudiantescursos);
        }

        // GET: Estudiantescursos/Create
        public IActionResult Create()
        {
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante");
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso");
            return View();
        }

        // POST: Estudiantescursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudianteCurso,CodigoEstudianteFk,IdCursoFk,FechaEstudianteCurso")] Estudiantescursos estudiantescursos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiantescursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantescursos.CodigoEstudianteFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", estudiantescursos.IdCursoFk);
            return View(estudiantescursos);
        }

        // GET: Estudiantescursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantescursos = await _context.Estudiantescursos.FindAsync(id);
            if (estudiantescursos == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantescursos.CodigoEstudianteFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", estudiantescursos.IdCursoFk);
            return View(estudiantescursos);
        }

        // POST: Estudiantescursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudianteCurso,CodigoEstudianteFk,IdCursoFk,FechaEstudianteCurso")] Estudiantescursos estudiantescursos)
        {
            if (id != estudiantescursos.IdEstudianteCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiantescursos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiantescursosExists(estudiantescursos.IdEstudianteCurso))
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
            ViewData["CodigoEstudianteFk"] = new SelectList(_context.Estudiantes, "CodigoEstudiante", "CodigoEstudiante", estudiantescursos.CodigoEstudianteFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", estudiantescursos.IdCursoFk);
            return View(estudiantescursos);
        }

        // GET: Estudiantescursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiantescursos = await _context.Estudiantescursos
                .Include(e => e.CodigoEstudianteFkNavigation)
                .Include(e => e.IdCursoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudianteCurso == id);
            if (estudiantescursos == null)
            {
                return NotFound();
            }

            return View(estudiantescursos);
        }

        // POST: Estudiantescursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiantescursos = await _context.Estudiantescursos.FindAsync(id);
            _context.Estudiantescursos.Remove(estudiantescursos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiantescursosExists(int id)
        {
            return _context.Estudiantescursos.Any(e => e.IdEstudianteCurso == id);
        }
    }
}
