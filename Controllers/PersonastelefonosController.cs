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
    public class PersonastelefonosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PersonastelefonosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Personastelefonos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Personastelefonos.Include(p => p.IdPersonaFkNavigation).Include(p => p.IdTelefonoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Personastelefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personastelefonos = await _context.Personastelefonos
                .Include(p => p.IdPersonaFkNavigation)
                .Include(p => p.IdTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaTelefono == id);
            if (personastelefonos == null)
            {
                return NotFound();
            }

            return View(personastelefonos);
        }

        // GET: Personastelefonos/Create
        public IActionResult Create()
        {
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono");
            return View();
        }

        // POST: Personastelefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonaTelefono,IdPersonaFk,IdTelefonoFk")] Personastelefonos personastelefonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personastelefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personastelefonos.IdPersonaFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", personastelefonos.IdTelefonoFk);
            return View(personastelefonos);
        }

        // GET: Personastelefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personastelefonos = await _context.Personastelefonos.FindAsync(id);
            if (personastelefonos == null)
            {
                return NotFound();
            }
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personastelefonos.IdPersonaFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", personastelefonos.IdTelefonoFk);
            return View(personastelefonos);
        }

        // POST: Personastelefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonaTelefono,IdPersonaFk,IdTelefonoFk")] Personastelefonos personastelefonos)
        {
            if (id != personastelefonos.IdPersonaTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personastelefonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonastelefonosExists(personastelefonos.IdPersonaTelefono))
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
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", personastelefonos.IdPersonaFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", personastelefonos.IdTelefonoFk);
            return View(personastelefonos);
        }

        // GET: Personastelefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personastelefonos = await _context.Personastelefonos
                .Include(p => p.IdPersonaFkNavigation)
                .Include(p => p.IdTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaTelefono == id);
            if (personastelefonos == null)
            {
                return NotFound();
            }

            return View(personastelefonos);
        }

        // POST: Personastelefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personastelefonos = await _context.Personastelefonos.FindAsync(id);
            _context.Personastelefonos.Remove(personastelefonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonastelefonosExists(int id)
        {
            return _context.Personastelefonos.Any(e => e.IdPersonaTelefono == id);
        }
    }
}
