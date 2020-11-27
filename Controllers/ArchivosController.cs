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
    public class ArchivosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public ArchivosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Archivos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Archivos.Include(a => a.IdEstadoFkNavigation).Include(a => a.IdPersonaFkNavigation).Include(a => a.IdTipoArchivoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Archivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivos = await _context.Archivos
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdPersonaFkNavigation)
                .Include(a => a.IdTipoArchivoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdArchivo == id);
            if (archivos == null)
            {
                return NotFound();
            }

            return View(archivos);
        }

        // GET: Archivos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdTipoArchivoFk"] = new SelectList(_context.Tiposarchivos, "IdTipoArchivo", "DescripcionTipoArchivo");
            return View();
        }

        // POST: Archivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArchivo,EnlaceArchivo,FechaArchivo,Hora,IdTipoArchivoFk,IdEstadoFk,IdPersonaFk")] Archivos archivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", archivos.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", archivos.IdPersonaFk);
            ViewData["IdTipoArchivoFk"] = new SelectList(_context.Tiposarchivos, "IdTipoArchivo", "DescripcionTipoArchivo", archivos.IdTipoArchivoFk);
            return View(archivos);
        }

        // GET: Archivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivos = await _context.Archivos.FindAsync(id);
            if (archivos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", archivos.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", archivos.IdPersonaFk);
            ViewData["IdTipoArchivoFk"] = new SelectList(_context.Tiposarchivos, "IdTipoArchivo", "DescripcionTipoArchivo", archivos.IdTipoArchivoFk);
            return View(archivos);
        }

        // POST: Archivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArchivo,EnlaceArchivo,FechaArchivo,Hora,IdTipoArchivoFk,IdEstadoFk,IdPersonaFk")] Archivos archivos)
        {
            if (id != archivos.IdArchivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchivosExists(archivos.IdArchivo))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", archivos.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", archivos.IdPersonaFk);
            ViewData["IdTipoArchivoFk"] = new SelectList(_context.Tiposarchivos, "IdTipoArchivo", "DescripcionTipoArchivo", archivos.IdTipoArchivoFk);
            return View(archivos);
        }

        // GET: Archivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archivos = await _context.Archivos
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdPersonaFkNavigation)
                .Include(a => a.IdTipoArchivoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdArchivo == id);
            if (archivos == null)
            {
                return NotFound();
            }

            return View(archivos);
        }

        // POST: Archivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archivos = await _context.Archivos.FindAsync(id);
            _context.Archivos.Remove(archivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchivosExists(int id)
        {
            return _context.Archivos.Any(e => e.IdArchivo == id);
        }
    }
}
