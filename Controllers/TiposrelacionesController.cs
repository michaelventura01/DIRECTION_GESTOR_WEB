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
    public class TiposrelacionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TiposrelacionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tiposrelaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposrelaciones.ToListAsync());
        }

        // GET: Tiposrelaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposrelaciones = await _context.Tiposrelaciones
                .FirstOrDefaultAsync(m => m.IdTipoRelacion == id);
            if (tiposrelaciones == null)
            {
                return NotFound();
            }

            return View(tiposrelaciones);
        }

        // GET: Tiposrelaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposrelaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoRelacion,DescripcionTipoRelacion")] Tiposrelaciones tiposrelaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposrelaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposrelaciones);
        }

        // GET: Tiposrelaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposrelaciones = await _context.Tiposrelaciones.FindAsync(id);
            if (tiposrelaciones == null)
            {
                return NotFound();
            }
            return View(tiposrelaciones);
        }

        // POST: Tiposrelaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoRelacion,DescripcionTipoRelacion")] Tiposrelaciones tiposrelaciones)
        {
            if (id != tiposrelaciones.IdTipoRelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposrelaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposrelacionesExists(tiposrelaciones.IdTipoRelacion))
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
            return View(tiposrelaciones);
        }

        // GET: Tiposrelaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposrelaciones = await _context.Tiposrelaciones
                .FirstOrDefaultAsync(m => m.IdTipoRelacion == id);
            if (tiposrelaciones == null)
            {
                return NotFound();
            }

            return View(tiposrelaciones);
        }

        // POST: Tiposrelaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposrelaciones = await _context.Tiposrelaciones.FindAsync(id);
            _context.Tiposrelaciones.Remove(tiposrelaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposrelacionesExists(int id)
        {
            return _context.Tiposrelaciones.Any(e => e.IdTipoRelacion == id);
        }
    }
}
