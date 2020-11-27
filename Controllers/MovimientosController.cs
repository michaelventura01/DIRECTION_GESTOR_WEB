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
    public class MovimientosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public MovimientosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Movimientos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Movimientos.Include(m => m.IdEstadoFkNavigation).Include(m => m.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Movimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.IdEstadoFkNavigation)
                .Include(m => m.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // GET: Movimientos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimiento,MontoMovimiento,DescripcionMovimiento,IdTipoMovimiento,FechaMovimiento,HoraMovimiento,IdEstadoFk,IdInstitucionFk")] Movimientos movimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", movimientos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", movimientos.IdInstitucionFk);
            return View(movimientos);
        }

        // GET: Movimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", movimientos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", movimientos.IdInstitucionFk);
            return View(movimientos);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMovimiento,MontoMovimiento,DescripcionMovimiento,IdTipoMovimiento,FechaMovimiento,HoraMovimiento,IdEstadoFk,IdInstitucionFk")] Movimientos movimientos)
        {
            if (id != movimientos.IdMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientosExists(movimientos.IdMovimiento))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", movimientos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", movimientos.IdInstitucionFk);
            return View(movimientos);
        }

        // GET: Movimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos
                .Include(m => m.IdEstadoFkNavigation)
                .Include(m => m.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return View(movimientos);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientos = await _context.Movimientos.FindAsync(id);
            _context.Movimientos.Remove(movimientos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientosExists(int id)
        {
            return _context.Movimientos.Any(e => e.IdMovimiento == id);
        }
    }
}
