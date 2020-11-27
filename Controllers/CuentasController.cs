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
    public class CuentasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public CuentasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Cuentas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Cuentas.Include(c => c.IdEstadoFkNavigation).Include(c => c.IdInstitucionFkNavigation).Include(c => c.IdPersonaFkNavigation).Include(c => c.IdTipoCuentaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Cuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .Include(c => c.IdPersonaFkNavigation)
                .Include(c => c.IdTipoCuentaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (cuentas == null)
            {
                return NotFound();
            }

            return View(cuentas);
        }

        // GET: Cuentas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdTipoCuentaFk"] = new SelectList(_context.Tipocuentas, "IdTipoCuenta", "DescripcionTipoCuenta");
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCuenta,DescripcionCuenta,MontoCuenta,FechaCuenta,IdTipoCuentaFk,IdPersonaFk,IdEstadoFk,IdInstitucionFk")] Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cuentas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", cuentas.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", cuentas.IdPersonaFk);
            ViewData["IdTipoCuentaFk"] = new SelectList(_context.Tipocuentas, "IdTipoCuenta", "DescripcionTipoCuenta", cuentas.IdTipoCuentaFk);
            return View(cuentas);
        }

        // GET: Cuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cuentas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", cuentas.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", cuentas.IdPersonaFk);
            ViewData["IdTipoCuentaFk"] = new SelectList(_context.Tipocuentas, "IdTipoCuenta", "DescripcionTipoCuenta", cuentas.IdTipoCuentaFk);
            return View(cuentas);
        }

        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCuenta,DescripcionCuenta,MontoCuenta,FechaCuenta,IdTipoCuentaFk,IdPersonaFk,IdEstadoFk,IdInstitucionFk")] Cuentas cuentas)
        {
            if (id != cuentas.IdCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentasExists(cuentas.IdCuenta))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", cuentas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", cuentas.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", cuentas.IdPersonaFk);
            ViewData["IdTipoCuentaFk"] = new SelectList(_context.Tipocuentas, "IdTipoCuenta", "DescripcionTipoCuenta", cuentas.IdTipoCuentaFk);
            return View(cuentas);
        }

        // GET: Cuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuentas = await _context.Cuentas
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .Include(c => c.IdPersonaFkNavigation)
                .Include(c => c.IdTipoCuentaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCuenta == id);
            if (cuentas == null)
            {
                return NotFound();
            }

            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuentas = await _context.Cuentas.FindAsync(id);
            _context.Cuentas.Remove(cuentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentasExists(int id)
        {
            return _context.Cuentas.Any(e => e.IdCuenta == id);
        }
    }
}
