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
    public class TipodocumentosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TipodocumentosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tipodocumentos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Tipodocumentos.Include(t => t.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Tipodocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumentos = await _context.Tipodocumentos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tipodocumentos == null)
            {
                return NotFound();
            }

            return View(tipodocumentos);
        }

        // GET: Tipodocumentos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Tipodocumentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDocumento,DescripcionTipoDocumento,IdEstadoFk")] Tipodocumentos tipodocumentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipodocumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipodocumentos.IdEstadoFk);
            return View(tipodocumentos);
        }

        // GET: Tipodocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumentos = await _context.Tipodocumentos.FindAsync(id);
            if (tipodocumentos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipodocumentos.IdEstadoFk);
            return View(tipodocumentos);
        }

        // POST: Tipodocumentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDocumento,DescripcionTipoDocumento,IdEstadoFk")] Tipodocumentos tipodocumentos)
        {
            if (id != tipodocumentos.IdTipoDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipodocumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipodocumentosExists(tipodocumentos.IdTipoDocumento))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipodocumentos.IdEstadoFk);
            return View(tipodocumentos);
        }

        // GET: Tipodocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumentos = await _context.Tipodocumentos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tipodocumentos == null)
            {
                return NotFound();
            }

            return View(tipodocumentos);
        }

        // POST: Tipodocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipodocumentos = await _context.Tipodocumentos.FindAsync(id);
            _context.Tipodocumentos.Remove(tipodocumentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipodocumentosExists(int id)
        {
            return _context.Tipodocumentos.Any(e => e.IdTipoDocumento == id);
        }
    }
}
