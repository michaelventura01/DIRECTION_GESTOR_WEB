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
    public class DireccionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public DireccionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Direcciones.Include(d => d.IdBarrioFkNavigation).Include(d => d.IdEstadoFkNavigation).Include(d => d.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones
                .Include(d => d.IdBarrioFkNavigation)
                .Include(d => d.IdEstadoFkNavigation)
                .Include(d => d.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direcciones == null)
            {
                return NotFound();
            }

            return View(direcciones);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            ViewData["IdBarrioFk"] = new SelectList(_context.Barrios, "IdBarrio", "DescripcionBarrio");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDireccion,DescripcionDireccion,IdEstadoFk,IdBarrioFk,IdInstitucionFk")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direcciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarrioFk"] = new SelectList(_context.Barrios, "IdBarrio", "DescripcionBarrio", direcciones.IdBarrioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", direcciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", direcciones.IdInstitucionFk);
            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return NotFound();
            }
            ViewData["IdBarrioFk"] = new SelectList(_context.Barrios, "IdBarrio", "DescripcionBarrio", direcciones.IdBarrioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", direcciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", direcciones.IdInstitucionFk);
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDireccion,DescripcionDireccion,IdEstadoFk,IdBarrioFk,IdInstitucionFk")] Direcciones direcciones)
        {
            if (id != direcciones.IdDireccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direcciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionesExists(direcciones.IdDireccion))
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
            ViewData["IdBarrioFk"] = new SelectList(_context.Barrios, "IdBarrio", "DescripcionBarrio", direcciones.IdBarrioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", direcciones.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", direcciones.IdInstitucionFk);
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direcciones = await _context.Direcciones
                .Include(d => d.IdBarrioFkNavigation)
                .Include(d => d.IdEstadoFkNavigation)
                .Include(d => d.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdDireccion == id);
            if (direcciones == null)
            {
                return NotFound();
            }

            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direcciones = await _context.Direcciones.FindAsync(id);
            _context.Direcciones.Remove(direcciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionesExists(int id)
        {
            return _context.Direcciones.Any(e => e.IdDireccion == id);
        }
    }
}
