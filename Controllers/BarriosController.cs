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
    public class BarriosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public BarriosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Barrios
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Barrios.Include(b => b.IdCiudadFkNavigation).Include(b => b.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Barrios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios
                .Include(b => b.IdCiudadFkNavigation)
                .Include(b => b.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrios == null)
            {
                return NotFound();
            }

            return View(barrios);
        }

        // GET: Barrios/Create
        public IActionResult Create()
        {
            ViewData["IdCiudadFk"] = new SelectList(_context.Ciudades, "IdCiudad", "IdCiudad");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Barrios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarrio,DescripcionBarrio,IdEstadoFk,IdCiudadFk")] Barrios barrios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barrios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCiudadFk"] = new SelectList(_context.Ciudades, "IdCiudad", "IdCiudad", barrios.IdCiudadFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", barrios.IdEstadoFk);
            return View(barrios);
        }

        // GET: Barrios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios.FindAsync(id);
            if (barrios == null)
            {
                return NotFound();
            }
            ViewData["IdCiudadFk"] = new SelectList(_context.Ciudades, "IdCiudad", "IdCiudad", barrios.IdCiudadFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", barrios.IdEstadoFk);
            return View(barrios);
        }

        // POST: Barrios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarrio,DescripcionBarrio,IdEstadoFk,IdCiudadFk")] Barrios barrios)
        {
            if (id != barrios.IdBarrio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barrios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarriosExists(barrios.IdBarrio))
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
            ViewData["IdCiudadFk"] = new SelectList(_context.Ciudades, "IdCiudad", "IdCiudad", barrios.IdCiudadFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", barrios.IdEstadoFk);
            return View(barrios);
        }

        // GET: Barrios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios
                .Include(b => b.IdCiudadFkNavigation)
                .Include(b => b.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrios == null)
            {
                return NotFound();
            }

            return View(barrios);
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barrios = await _context.Barrios.FindAsync(id);
            _context.Barrios.Remove(barrios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarriosExists(int id)
        {
            return _context.Barrios.Any(e => e.IdBarrio == id);
        }
    }
}
