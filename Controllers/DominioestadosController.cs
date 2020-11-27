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
    public class DominioestadosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public DominioestadosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Dominioestados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dominioestados.ToListAsync());
        }

        // GET: Dominioestados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dominioestados = await _context.Dominioestados
                .FirstOrDefaultAsync(m => m.IdDominioEstado == id);
            if (dominioestados == null)
            {
                return NotFound();
            }

            return View(dominioestados);
        }

        // GET: Dominioestados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dominioestados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDominioEstado,DescripcionDominioEstado")] Dominioestados dominioestados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dominioestados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dominioestados);
        }

        // GET: Dominioestados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dominioestados = await _context.Dominioestados.FindAsync(id);
            if (dominioestados == null)
            {
                return NotFound();
            }
            return View(dominioestados);
        }

        // POST: Dominioestados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDominioEstado,DescripcionDominioEstado")] Dominioestados dominioestados)
        {
            if (id != dominioestados.IdDominioEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dominioestados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DominioestadosExists(dominioestados.IdDominioEstado))
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
            return View(dominioestados);
        }

        // GET: Dominioestados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dominioestados = await _context.Dominioestados
                .FirstOrDefaultAsync(m => m.IdDominioEstado == id);
            if (dominioestados == null)
            {
                return NotFound();
            }

            return View(dominioestados);
        }

        // POST: Dominioestados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dominioestados = await _context.Dominioestados.FindAsync(id);
            _context.Dominioestados.Remove(dominioestados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DominioestadosExists(int id)
        {
            return _context.Dominioestados.Any(e => e.IdDominioEstado == id);
        }
    }
}
