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
    public class PuestostrabajosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PuestostrabajosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Puestostrabajos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puestostrabajos.ToListAsync());
        }

        // GET: Puestostrabajos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestostrabajos = await _context.Puestostrabajos
                .FirstOrDefaultAsync(m => m.IdPuestoTrabajo == id);
            if (puestostrabajos == null)
            {
                return NotFound();
            }

            return View(puestostrabajos);
        }

        // GET: Puestostrabajos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puestostrabajos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPuestoTrabajo,DescripcionPuestoTrabajo")] Puestostrabajos puestostrabajos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestostrabajos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestostrabajos);
        }

        // GET: Puestostrabajos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestostrabajos = await _context.Puestostrabajos.FindAsync(id);
            if (puestostrabajos == null)
            {
                return NotFound();
            }
            return View(puestostrabajos);
        }

        // POST: Puestostrabajos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPuestoTrabajo,DescripcionPuestoTrabajo")] Puestostrabajos puestostrabajos)
        {
            if (id != puestostrabajos.IdPuestoTrabajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestostrabajos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestostrabajosExists(puestostrabajos.IdPuestoTrabajo))
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
            return View(puestostrabajos);
        }

        // GET: Puestostrabajos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puestostrabajos = await _context.Puestostrabajos
                .FirstOrDefaultAsync(m => m.IdPuestoTrabajo == id);
            if (puestostrabajos == null)
            {
                return NotFound();
            }

            return View(puestostrabajos);
        }

        // POST: Puestostrabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puestostrabajos = await _context.Puestostrabajos.FindAsync(id);
            _context.Puestostrabajos.Remove(puestostrabajos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestostrabajosExists(int id)
        {
            return _context.Puestostrabajos.Any(e => e.IdPuestoTrabajo == id);
        }
    }
}
