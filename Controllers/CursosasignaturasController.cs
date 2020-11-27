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
    public class CursosasignaturasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public CursosasignaturasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Cursosasignaturas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Cursosasignaturas.Include(c => c.IdAsignaturaFkNavigation).Include(c => c.IdCursoFkNavigation).Include(c => c.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Cursosasignaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursosasignaturas = await _context.Cursosasignaturas
                .Include(c => c.IdAsignaturaFkNavigation)
                .Include(c => c.IdCursoFkNavigation)
                .Include(c => c.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCursoAsignatura == id);
            if (cursosasignaturas == null)
            {
                return NotFound();
            }

            return View(cursosasignaturas);
        }

        // GET: Cursosasignaturas/Create
        public IActionResult Create()
        {
            ViewData["IdAsignaturaFk"] = new SelectList(_context.Asignaturas, "IdAsignatura", "DescripcionAsignatura");
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Cursosasignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCursoAsignatura,IdAsignaturaFk,IdCursoFk,IdEstadoFk")] Cursosasignaturas cursosasignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursosasignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignaturaFk"] = new SelectList(_context.Asignaturas, "IdAsignatura", "DescripcionAsignatura", cursosasignaturas.IdAsignaturaFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", cursosasignaturas.IdCursoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cursosasignaturas.IdEstadoFk);
            return View(cursosasignaturas);
        }

        // GET: Cursosasignaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursosasignaturas = await _context.Cursosasignaturas.FindAsync(id);
            if (cursosasignaturas == null)
            {
                return NotFound();
            }
            ViewData["IdAsignaturaFk"] = new SelectList(_context.Asignaturas, "IdAsignatura", "DescripcionAsignatura", cursosasignaturas.IdAsignaturaFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", cursosasignaturas.IdCursoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cursosasignaturas.IdEstadoFk);
            return View(cursosasignaturas);
        }

        // POST: Cursosasignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCursoAsignatura,IdAsignaturaFk,IdCursoFk,IdEstadoFk")] Cursosasignaturas cursosasignaturas)
        {
            if (id != cursosasignaturas.IdCursoAsignatura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursosasignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursosasignaturasExists(cursosasignaturas.IdCursoAsignatura))
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
            ViewData["IdAsignaturaFk"] = new SelectList(_context.Asignaturas, "IdAsignatura", "DescripcionAsignatura", cursosasignaturas.IdAsignaturaFk);
            ViewData["IdCursoFk"] = new SelectList(_context.Cursos, "IdCurso", "DescripcionCurso", cursosasignaturas.IdCursoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cursosasignaturas.IdEstadoFk);
            return View(cursosasignaturas);
        }

        // GET: Cursosasignaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursosasignaturas = await _context.Cursosasignaturas
                .Include(c => c.IdAsignaturaFkNavigation)
                .Include(c => c.IdCursoFkNavigation)
                .Include(c => c.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCursoAsignatura == id);
            if (cursosasignaturas == null)
            {
                return NotFound();
            }

            return View(cursosasignaturas);
        }

        // POST: Cursosasignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursosasignaturas = await _context.Cursosasignaturas.FindAsync(id);
            _context.Cursosasignaturas.Remove(cursosasignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursosasignaturasExists(int id)
        {
            return _context.Cursosasignaturas.Any(e => e.IdCursoAsignatura == id);
        }
    }
}
