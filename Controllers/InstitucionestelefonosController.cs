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
    public class InstitucionestelefonosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public InstitucionestelefonosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Institucionestelefonos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Institucionestelefonos.Include(i => i.IdEstadoFkNavigation).Include(i => i.IdInstitucionFkNavigation).Include(i => i.IdTelefonoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Institucionestelefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionestelefonos = await _context.Institucionestelefonos
                .Include(i => i.IdEstadoFkNavigation)
                .Include(i => i.IdInstitucionFkNavigation)
                .Include(i => i.IdTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucionTelefono == id);
            if (institucionestelefonos == null)
            {
                return NotFound();
            }

            return View(institucionestelefonos);
        }

        // GET: Institucionestelefonos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "NombreInstitucion");
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono");
            return View();
        }

        // POST: Institucionestelefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstitucionTelefono,IdInstitucionFk,IdTelefonoFk,IdEstadoFk")] Institucionestelefonos institucionestelefonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institucionestelefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionestelefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "NombreInstitucion", institucionestelefonos.IdInstitucionFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", institucionestelefonos.IdTelefonoFk);
            return View(institucionestelefonos);
        }

        // GET: Institucionestelefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionestelefonos = await _context.Institucionestelefonos.FindAsync(id);
            if (institucionestelefonos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionestelefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "NombreInstitucion", institucionestelefonos.IdInstitucionFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", institucionestelefonos.IdTelefonoFk);
            return View(institucionestelefonos);
        }

        // POST: Institucionestelefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstitucionTelefono,IdInstitucionFk,IdTelefonoFk,IdEstadoFk")] Institucionestelefonos institucionestelefonos)
        {
            if (id != institucionestelefonos.IdInstitucionTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institucionestelefonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitucionestelefonosExists(institucionestelefonos.IdInstitucionTelefono))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", institucionestelefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "nombreInstitucion", institucionestelefonos.IdInstitucionFk);
            ViewData["IdTelefonoFk"] = new SelectList(_context.Telefonos, "IdTelefono", "DescripcionTelefono", institucionestelefonos.IdTelefonoFk);
            return View(institucionestelefonos);
        }

        // GET: Institucionestelefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institucionestelefonos = await _context.Institucionestelefonos
                .Include(i => i.IdEstadoFkNavigation)
                .Include(i => i.IdInstitucionFkNavigation)
                .Include(i => i.IdTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdInstitucionTelefono == id);
            if (institucionestelefonos == null)
            {
                return NotFound();
            }

            return View(institucionestelefonos);
        }

        // POST: Institucionestelefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institucionestelefonos = await _context.Institucionestelefonos.FindAsync(id);
            _context.Institucionestelefonos.Remove(institucionestelefonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitucionestelefonosExists(int id)
        {
            return _context.Institucionestelefonos.Any(e => e.IdInstitucionTelefono == id);
        }
    }
}
