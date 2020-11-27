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
    public class PrioridadesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PrioridadesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Prioridades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prioridades.ToListAsync());
        }

        // GET: Prioridades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.IdPrioridad == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // GET: Prioridades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prioridades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrioridad,DescripcionPrioridad")] Prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prioridades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridades);
        }

        // GET: Prioridades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }
            return View(prioridades);
        }

        // POST: Prioridades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrioridad,DescripcionPrioridad")] Prioridades prioridades)
        {
            if (id != prioridades.IdPrioridad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prioridades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrioridadesExists(prioridades.IdPrioridad))
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
            return View(prioridades);
        }

        // GET: Prioridades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .FirstOrDefaultAsync(m => m.IdPrioridad == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // POST: Prioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prioridades = await _context.Prioridades.FindAsync(id);
            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrioridadesExists(int id)
        {
            return _context.Prioridades.Any(e => e.IdPrioridad == id);
        }
    }
}
