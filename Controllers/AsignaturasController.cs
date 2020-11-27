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
    public class AsignaturasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public AsignaturasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Asignaturas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Asignaturas.Include(a => a.IdEstadoFkNavigation).Include(a => a.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Asignaturas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignatura == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // GET: Asignaturas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Asignaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignatura,DescripcionAsignatura,IdEstadoFk,IdInstitucionFk")] Asignaturas asignaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", asignaturas.IdInstitucionFk);
            return View(asignaturas);
        }

        // GET: Asignaturas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas.FindAsync(id);
            if (asignaturas == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", asignaturas.IdInstitucionFk);
            return View(asignaturas);
        }

        // POST: Asignaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAsignatura,DescripcionAsignatura,IdEstadoFk,IdInstitucionFk")] Asignaturas asignaturas)
        {
            if (id != asignaturas.IdAsignatura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasExists(asignaturas.IdAsignatura))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", asignaturas.IdInstitucionFk);
            return View(asignaturas);
        }

        // GET: Asignaturas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturas = await _context.Asignaturas
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignatura == id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            return View(asignaturas);
        }

        // POST: Asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var asignaturas = await _context.Asignaturas.FindAsync(id);
            _context.Asignaturas.Remove(asignaturas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasExists(string id)
        {
            return _context.Asignaturas.Any(e => e.IdAsignatura == id);
        }
    }
}
