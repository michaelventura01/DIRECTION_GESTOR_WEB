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
    public class TiposarchivosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TiposarchivosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tiposarchivos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Tiposarchivos.Include(t => t.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Tiposarchivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposarchivos = await _context.Tiposarchivos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoArchivo == id);
            if (tiposarchivos == null)
            {
                return NotFound();
            }

            return View(tiposarchivos);
        }

        // GET: Tiposarchivos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Tiposarchivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoArchivo,DescripcionTipoArchivo,TerminalTipoArchivo,IdEstadoFk")] Tiposarchivos tiposarchivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposarchivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tiposarchivos.IdEstadoFk);
            return View(tiposarchivos);
        }

        // GET: Tiposarchivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposarchivos = await _context.Tiposarchivos.FindAsync(id);
            if (tiposarchivos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tiposarchivos.IdEstadoFk);
            return View(tiposarchivos);
        }

        // POST: Tiposarchivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoArchivo,DescripcionTipoArchivo,TerminalTipoArchivo,IdEstadoFk")] Tiposarchivos tiposarchivos)
        {
            if (id != tiposarchivos.IdTipoArchivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposarchivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposarchivosExists(tiposarchivos.IdTipoArchivo))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tiposarchivos.IdEstadoFk);
            return View(tiposarchivos);
        }

        // GET: Tiposarchivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposarchivos = await _context.Tiposarchivos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoArchivo == id);
            if (tiposarchivos == null)
            {
                return NotFound();
            }

            return View(tiposarchivos);
        }

        // POST: Tiposarchivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposarchivos = await _context.Tiposarchivos.FindAsync(id);
            _context.Tiposarchivos.Remove(tiposarchivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposarchivosExists(int id)
        {
            return _context.Tiposarchivos.Any(e => e.IdTipoArchivo == id);
        }
    }
}
