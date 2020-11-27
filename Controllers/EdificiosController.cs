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
    public class EdificiosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EdificiosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Edificios
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Edificios.Include(e => e.IdDireccionFkNavigation).Include(e => e.IdEstadoFkNavigation).Include(e => e.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Edificios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios
                .Include(e => e.IdDireccionFkNavigation)
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEdificio == id);
            if (edificios == null)
            {
                return NotFound();
            }

            return View(edificios);
        }

        // GET: Edificios/Create
        public IActionResult Create()
        {
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Edificios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEdificio,DescripcionEdificio,IdEstadoFk,IdDireccionFk,IdInstitucionFk")] Edificios edificios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edificios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", edificios.IdDireccionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", edificios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", edificios.IdInstitucionFk);
            return View(edificios);
        }

        // GET: Edificios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios.FindAsync(id);
            if (edificios == null)
            {
                return NotFound();
            }
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", edificios.IdDireccionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", edificios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", edificios.IdInstitucionFk);
            return View(edificios);
        }

        // POST: Edificios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEdificio,DescripcionEdificio,IdEstadoFk,IdDireccionFk,IdInstitucionFk")] Edificios edificios)
        {
            if (id != edificios.IdEdificio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edificios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdificiosExists(edificios.IdEdificio))
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
            ViewData["IdDireccionFk"] = new SelectList(_context.Direcciones, "IdDireccion", "DescripcionDireccion", edificios.IdDireccionFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", edificios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", edificios.IdInstitucionFk);
            return View(edificios);
        }

        // GET: Edificios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios
                .Include(e => e.IdDireccionFkNavigation)
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEdificio == id);
            if (edificios == null)
            {
                return NotFound();
            }

            return View(edificios);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edificios = await _context.Edificios.FindAsync(id);
            _context.Edificios.Remove(edificios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdificiosExists(int id)
        {
            return _context.Edificios.Any(e => e.IdEdificio == id);
        }
    }
}
