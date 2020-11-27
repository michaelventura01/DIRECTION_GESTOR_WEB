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
    public class SexosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public SexosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sexos.ToListAsync());
        }

        // GET: Sexos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexos = await _context.Sexos
                .FirstOrDefaultAsync(m => m.IdSexo == id);
            if (sexos == null)
            {
                return NotFound();
            }

            return View(sexos);
        }

        // GET: Sexos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sexos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSexo,DescripcionSexo")] Sexos sexos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sexos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sexos);
        }

        // GET: Sexos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexos = await _context.Sexos.FindAsync(id);
            if (sexos == null)
            {
                return NotFound();
            }
            return View(sexos);
        }

        // POST: Sexos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSexo,DescripcionSexo")] Sexos sexos)
        {
            if (id != sexos.IdSexo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sexos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SexosExists(sexos.IdSexo))
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
            return View(sexos);
        }

        // GET: Sexos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sexos = await _context.Sexos
                .FirstOrDefaultAsync(m => m.IdSexo == id);
            if (sexos == null)
            {
                return NotFound();
            }

            return View(sexos);
        }

        // POST: Sexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sexos = await _context.Sexos.FindAsync(id);
            _context.Sexos.Remove(sexos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SexosExists(int id)
        {
            return _context.Sexos.Any(e => e.IdSexo == id);
        }
    }
}
