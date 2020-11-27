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
    public class PaisesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PaisesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Paises
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Paises.Include(p => p.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises
                .Include(p => p.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPais == id);
            if (paises == null)
            {
                return NotFound();
            }

            return View(paises);
        }

        // GET: Paises/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPais,DescripcionPais,IdEstadoFk,Nacionalidad")] Paises paises)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paises);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", paises.IdEstadoFk);
            return View(paises);
        }

        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises.FindAsync(id);
            if (paises == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", paises.IdEstadoFk);
            return View(paises);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPais,DescripcionPais,IdEstadoFk,Nacionalidad")] Paises paises)
        {
            if (id != paises.IdPais)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paises);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisesExists(paises.IdPais))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", paises.IdEstadoFk);
            return View(paises);
        }

        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paises = await _context.Paises
                .Include(p => p.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPais == id);
            if (paises == null)
            {
                return NotFound();
            }

            return View(paises);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var paises = await _context.Paises.FindAsync(id);
            _context.Paises.Remove(paises);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisesExists(string id)
        {
            return _context.Paises.Any(e => e.IdPais == id);
        }
    }
}
