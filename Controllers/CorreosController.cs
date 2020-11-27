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
    public class CorreosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public CorreosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Correos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Correos.Include(c => c.IdEstadoFkNavigation).Include(c => c.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Correos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correos = await _context.Correos
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (correos == null)
            {
                return NotFound();
            }

            return View(correos);
        }

        // GET: Correos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Correos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorreo,DescripcionCorreo,IdEstadoFk,IdInstitucionFk")] Correos correos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", correos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", correos.IdInstitucionFk);
            return View(correos);
        }

        // GET: Correos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correos = await _context.Correos.FindAsync(id);
            if (correos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", correos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", correos.IdInstitucionFk);
            return View(correos);
        }

        // POST: Correos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCorreo,DescripcionCorreo,IdEstadoFk,IdInstitucionFk")] Correos correos)
        {
            if (id != correos.IdCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorreosExists(correos.IdCorreo))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", correos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", correos.IdInstitucionFk);
            return View(correos);
        }

        // GET: Correos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correos = await _context.Correos
                .Include(c => c.IdEstadoFkNavigation)
                .Include(c => c.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdCorreo == id);
            if (correos == null)
            {
                return NotFound();
            }

            return View(correos);
        }

        // POST: Correos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correos = await _context.Correos.FindAsync(id);
            _context.Correos.Remove(correos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreosExists(int id)
        {
            return _context.Correos.Any(e => e.IdCorreo == id);
        }
    }
}
