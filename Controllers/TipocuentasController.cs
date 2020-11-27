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
    public class TipocuentasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TipocuentasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tipocuentas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Tipocuentas.Include(t => t.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Tipocuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocuentas = await _context.Tipocuentas
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoCuenta == id);
            if (tipocuentas == null)
            {
                return NotFound();
            }

            return View(tipocuentas);
        }

        // GET: Tipocuentas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Tipocuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCuenta,DescripcionTipoCuenta,IdEstadoFk")] Tipocuentas tipocuentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipocuentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipocuentas.IdEstadoFk);
            return View(tipocuentas);
        }

        // GET: Tipocuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocuentas = await _context.Tipocuentas.FindAsync(id);
            if (tipocuentas == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipocuentas.IdEstadoFk);
            return View(tipocuentas);
        }

        // POST: Tipocuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCuenta,DescripcionTipoCuenta,IdEstadoFk")] Tipocuentas tipocuentas)
        {
            if (id != tipocuentas.IdTipoCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipocuentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipocuentasExists(tipocuentas.IdTipoCuenta))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tipocuentas.IdEstadoFk);
            return View(tipocuentas);
        }

        // GET: Tipocuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocuentas = await _context.Tipocuentas
                .Include(t => t.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoCuenta == id);
            if (tipocuentas == null)
            {
                return NotFound();
            }

            return View(tipocuentas);
        }

        // POST: Tipocuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipocuentas = await _context.Tipocuentas.FindAsync(id);
            _context.Tipocuentas.Remove(tipocuentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipocuentasExists(int id)
        {
            return _context.Tipocuentas.Any(e => e.IdTipoCuenta == id);
        }
    }
}
