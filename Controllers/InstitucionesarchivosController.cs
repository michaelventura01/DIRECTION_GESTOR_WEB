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
    public class InstitucionesarchivosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public InstitucionesarchivosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Institucionesarchivos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Institucionesarchivos.Include(i => i.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Institucionesarchivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionesarchivos = await _context.Institucionesarchivos
                .Include(i => i.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdArchivo == id);
            if (institucionesarchivos == null)
            {
                return NotFound();
            }

            return View(institucionesarchivos);
        }

        // GET: Institucionesarchivos/Create
        public IActionResult Create()
        {
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Institucionesarchivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArchivo,EnlaceArchivo,FechaArchivo,Hora,IdTipoArchivoFk,IdEstadoFk,IdInstitucionFk")] Institucionesarchivos institucionesarchivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucionesarchivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", institucionesarchivos.IdInstitucionFk);
            return View(institucionesarchivos);
        }

        // GET: Institucionesarchivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionesarchivos = await _context.Institucionesarchivos.FindAsync(id);
            if (institucionesarchivos == null)
            {
                return NotFound();
            }
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", institucionesarchivos.IdInstitucionFk);
            return View(institucionesarchivos);
        }

        // POST: Institucionesarchivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArchivo,EnlaceArchivo,FechaArchivo,Hora,IdTipoArchivoFk,IdEstadoFk,IdInstitucionFk")] Institucionesarchivos institucionesarchivos)
        {
            if (id != institucionesarchivos.IdArchivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucionesarchivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionesarchivosExists(institucionesarchivos.IdArchivo))
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
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", institucionesarchivos.IdInstitucionFk);
            return View(institucionesarchivos);
        }

        // GET: Institucionesarchivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionesarchivos = await _context.Institucionesarchivos
                .Include(i => i.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdArchivo == id);
            if (institucionesarchivos == null)
            {
                return NotFound();
            }

            return View(institucionesarchivos);
        }

        // POST: Institucionesarchivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucionesarchivos = await _context.Institucionesarchivos.FindAsync(id);
            _context.Institucionesarchivos.Remove(institucionesarchivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionesarchivosExists(int id)
        {
            return _context.Institucionesarchivos.Any(e => e.IdArchivo == id);
        }
    }
}
