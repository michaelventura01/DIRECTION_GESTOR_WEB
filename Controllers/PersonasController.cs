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
    public class PersonasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public PersonasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Personas.Include(p => p.IdDireccionFkNavigation).Include(p => p.IdSexoFkNavigation).Include(p => p.NacionalidadPaisFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.IdDireccionFkNavigation)
                .Include(p => p.IdSexoFkNavigation)
                .Include(p => p.NacionalidadPaisFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion");
            ViewData["IdSexoFk"] = new SelectList(_context.Sexos, "IdSexo", "DescripcionSexo");
            ViewData["NacionalidadPaisFk"] = new SelectList(_context.Paises, "IdPais", "IdPais");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,NombrePersonas,ApellidoPersonas,FechaNacimientoPersona,IdDireccionFk,IdSexoFk,NacionalidadPaisFk")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", personas.IdDireccionFk);
            ViewData["IdSexoFk"] = new SelectList(_context.Sexos, "IdSexo", "DescripcionSexo", personas.IdSexoFk);
            ViewData["NacionalidadPaisFk"] = new SelectList(_context.Paises, "IdPais", "IdPais", personas.NacionalidadPaisFk);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas.FindAsync(id);
            if (personas == null)
            {
                return NotFound();
            }
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", personas.IdDireccionFk);
            ViewData["IdSexoFk"] = new SelectList(_context.Sexos, "IdSexo", "DescripcionSexo", personas.IdSexoFk);
            ViewData["NacionalidadPaisFk"] = new SelectList(_context.Paises, "IdPais", "IdPais", personas.NacionalidadPaisFk);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,NombrePersonas,ApellidoPersonas,FechaNacimientoPersona,IdDireccionFk,IdSexoFk,NacionalidadPaisFk")] Personas personas)
        {
            if (id != personas.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasExists(personas.IdPersona))
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
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", personas.IdDireccionFk);
            ViewData["IdSexoFk"] = new SelectList(_context.Sexos, "IdSexo", "DescripcionSexo", personas.IdSexoFk);
            ViewData["NacionalidadPaisFk"] = new SelectList(_context.Paises, "IdPais", "IdPais", personas.NacionalidadPaisFk);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.IdDireccionFkNavigation)
                .Include(p => p.IdSexoFkNavigation)
                .Include(p => p.NacionalidadPaisFkNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personas = await _context.Personas.FindAsync(id);
            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
