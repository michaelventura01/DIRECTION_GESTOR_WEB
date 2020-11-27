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
    public class InstitucionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public InstitucionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Instituciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Instituciones.Include(i => i.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        public ActionResult Agregar()
        {
            return View();
        }

        // GET: Instituciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituciones = await _context.Instituciones
                .Include(i => i.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucion == id);
            if (instituciones == null)
            {
                return NotFound();
            }

            return View(instituciones);
        }

        // GET: Instituciones/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Instituciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstitucion,NombreInstitucion,DescripcionInstitucion,IdEstadoFk")] Instituciones instituciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituciones);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", instituciones.IdEstadoFk);
            return View(instituciones);
            
        }

        // GET: Instituciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituciones = await _context.Instituciones.FindAsync(id);
            if (instituciones == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", instituciones.IdEstadoFk);
            return View(instituciones);
        }

        // POST: Instituciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstitucion,NombreInstitucion,DescripcionInstitucion,IdEstadoFk")] Instituciones instituciones)
        {
            if (id != instituciones.IdInstitucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionesExists(instituciones.IdInstitucion))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", instituciones.IdEstadoFk);
            return View(instituciones);
        }

        // GET: Instituciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituciones = await _context.Instituciones
                .Include(i => i.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucion == id);
            if (instituciones == null)
            {
                return NotFound();
            }

            return View(instituciones);
        }

        // POST: Instituciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituciones = await _context.Instituciones.FindAsync(id);
            _context.Instituciones.Remove(instituciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionesExists(int id)
        {
            return _context.Instituciones.Any(e => e.IdInstitucion == id);
        }
    }
}
