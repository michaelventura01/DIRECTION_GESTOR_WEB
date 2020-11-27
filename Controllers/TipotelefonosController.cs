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
    public class TipotelefonosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TipotelefonosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tipotelefonos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Tipotelefonos.Include(t => t.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Tipotelefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotelefonos = await _context.Tipotelefonos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoTelefono == id);
            if (tipotelefonos == null)
            {
                return NotFound();
            }

            return View(tipotelefonos);
        }

        // GET: Tipotelefonos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Tipotelefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTelefono,DescripcionTipoTelefono,IdEstadoFk")] Tipotelefonos tipotelefonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipotelefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipotelefonos.IdEstadoFk);
            return View(tipotelefonos);
        }

        // GET: Tipotelefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotelefonos = await _context.Tipotelefonos.FindAsync(id);
            if (tipotelefonos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipotelefonos.IdEstadoFk);
            return View(tipotelefonos);
        }

        // POST: Tipotelefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTelefono,DescripcionTipoTelefono,IdEstadoFk")] Tipotelefonos tipotelefonos)
        {
            if (id != tipotelefonos.IdTipoTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipotelefonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipotelefonosExists(tipotelefonos.IdTipoTelefono))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipotelefonos.IdEstadoFk);
            return View(tipotelefonos);
        }

        // GET: Tipotelefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipotelefonos = await _context.Tipotelefonos
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoTelefono == id);
            if (tipotelefonos == null)
            {
                return NotFound();
            }

            return View(tipotelefonos);
        }

        // POST: Tipotelefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipotelefonos = await _context.Tipotelefonos.FindAsync(id);
            _context.Tipotelefonos.Remove(tipotelefonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipotelefonosExists(int id)
        {
            return _context.Tipotelefonos.Any(e => e.IdTipoTelefono == id);
        }
    }
}
