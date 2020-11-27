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
    public class InstitucionescorreosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public InstitucionescorreosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Institucionescorreos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Institucionescorreos.Include(i => i.IdCorreoFkNavigation).Include(i => i.IdEstadoFkNavigation).Include(i => i.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Institucionescorreos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionescorreos = await _context.Institucionescorreos
                .Include(i => i.IdCorreoFkNavigation)
                .Include(i => i.IdEstadoFkNavigation)
                .Include(i => i.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucionCorreo == id);
            if (institucionescorreos == null)
            {
                return NotFound();
            }

            return View(institucionescorreos);
        }

        // GET: Institucionescorreos/Create
        public IActionResult Create()
        {
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Institucionescorreos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstitucionCorreo,IdInstitucionFk,IdCorreoFk,IdEstadoFk")] Institucionescorreos institucionescorreos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucionescorreos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", institucionescorreos.IdCorreoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionescorreos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "nombreInstitucion", institucionescorreos.IdInstitucionFk);
            return View(institucionescorreos);
        }

        // GET: Institucionescorreos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionescorreos = await _context.Institucionescorreos.FindAsync(id);
            if (institucionescorreos == null)
            {
                return NotFound();
            }
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", institucionescorreos.IdCorreoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionescorreos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "nombreInstitucion", institucionescorreos.IdInstitucionFk);
            return View(institucionescorreos);
        }

        // POST: Institucionescorreos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstitucionCorreo,IdInstitucionFk,IdCorreoFk,IdEstadoFk")] Institucionescorreos institucionescorreos)
        {
            if (id != institucionescorreos.IdInstitucionCorreo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucionescorreos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionescorreosExists(institucionescorreos.IdInstitucionCorreo))
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
            ViewData["IdCorreoFk"] = new SelectList(_context.Correos, "IdCorreo", "DescripcionCorreo", institucionescorreos.IdCorreoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionescorreos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "nombreInstitucion", institucionescorreos.IdInstitucionFk);
            return View(institucionescorreos);
        }

        // GET: Institucionescorreos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionescorreos = await _context.Institucionescorreos
                .Include(i => i.IdCorreoFkNavigation)
                .Include(i => i.IdEstadoFkNavigation)
                .Include(i => i.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucionCorreo == id);
            if (institucionescorreos == null)
            {
                return NotFound();
            }

            return View(institucionescorreos);
        }

        // POST: Institucionescorreos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucionescorreos = await _context.Institucionescorreos.FindAsync(id);
            _context.Institucionescorreos.Remove(institucionescorreos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionescorreosExists(int id)
        {
            return _context.Institucionescorreos.Any(e => e.IdInstitucionCorreo == id);
        }
    }
}
