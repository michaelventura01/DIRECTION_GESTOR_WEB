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
    public class PersonascorreosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PersonascorreosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Personascorreos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Personascorreos.Include(p => p.IdCorreoFkNavigation).Include(p => p.IdPersonaFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Personascorreos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personascorreos = await _context.Personascorreos
                .Include(p => p.IdCorreoFkNavigation)
                .Include(p => p.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaCorreo == id);
            if (personascorreos == null)
            {
                return NotFound();
            }

            return View(personascorreos);
        }

        // GET: Personascorreos/Create
        public IActionResult Create()
        {
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            return View();
        }

        // POST: Personascorreos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonaCorreo,IdPersonaFk,IdCorreoFk")] Personascorreos personascorreos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personascorreos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", personascorreos.IdCorreoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personascorreos.IdPersonaFk);
            return View(personascorreos);
        }

        // GET: Personascorreos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personascorreos = await _context.Personascorreos.FindAsync(id);
            if (personascorreos == null)
            {
                return NotFound();
            }
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", personascorreos.IdCorreoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personascorreos.IdPersonaFk);
            return View(personascorreos);
        }

        // POST: Personascorreos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonaCorreo,IdPersonaFk,IdCorreoFk")] Personascorreos personascorreos)
        {
            if (id != personascorreos.IdPersonaCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personascorreos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonascorreosExists(personascorreos.IdPersonaCorreo))
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
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", personascorreos.IdCorreoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personascorreos.IdPersonaFk);
            return View(personascorreos);
        }

        // GET: Personascorreos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personascorreos = await _context.Personascorreos
                .Include(p => p.IdCorreoFkNavigation)
                .Include(p => p.IdPersonaFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaCorreo == id);
            if (personascorreos == null)
            {
                return NotFound();
            }

            return View(personascorreos);
        }

        // POST: Personascorreos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personascorreos = await _context.Personascorreos.FindAsync(id);
            _context.Personascorreos.Remove(personascorreos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonascorreosExists(int id)
        {
            return _context.Personascorreos.Any(e => e.IdPersonaCorreo == id);
        }
    }
}
