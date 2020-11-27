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
    public class TelefonosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TelefonosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Telefonos
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Telefonos.Include(t => t.IdEstadoFkNavigation).Include(t => t.IdInstitucionFkNavigation).Include(t => t.IdTipoTelefonoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Telefonos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos
                .Include(t => t.IdEstadoFkNavigation)
                .Include(t => t.IdInstitucionFkNavigation)
                .Include(t => t.IdTipoTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefonos == null)
            {
                return NotFound();
            }

            return View(telefonos);
        }

        // GET: Telefonos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdTipoTelefonoFk"] = new SelectList(_context.Tipotelefonos, "IdTipoTelefono", "DescripcionTipoTelefono");
            return View();
        }

        // POST: Telefonos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTelefono,DescripcionTelefono,IdTipoTelefonoFk,IdEstadoFk,IdInstitucionFk")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", telefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", telefonos.IdInstitucionFk);
            ViewData["IdTipoTelefonoFk"] = new SelectList(_context.Tipotelefonos, "IdTipoTelefono", "DescripcionTipoTelefono", telefonos.IdTipoTelefonoFk);
            return View(telefonos);
        }

        // GET: Telefonos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos.FindAsync(id);
            if (telefonos == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", telefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", telefonos.IdInstitucionFk);
            ViewData["IdTipoTelefonoFk"] = new SelectList(_context.Tipotelefonos, "IdTipoTelefono", "DescripcionTipoTelefono", telefonos.IdTipoTelefonoFk);
            return View(telefonos);
        }

        // POST: Telefonos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTelefono,DescripcionTelefono,IdTipoTelefonoFk,IdEstadoFk,IdInstitucionFk")] Telefonos telefonos)
        {
            if (id != telefonos.IdTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonosExists(telefonos.IdTelefono))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", telefonos.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", telefonos.IdInstitucionFk);
            ViewData["IdTipoTelefonoFk"] = new SelectList(_context.Tipotelefonos, "IdTipoTelefono", "DescripcionTipoTelefono", telefonos.IdTipoTelefonoFk);
            return View(telefonos);
        }

        // GET: Telefonos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonos = await _context.Telefonos
                .Include(t => t.IdEstadoFkNavigation)
                .Include(t => t.IdInstitucionFkNavigation)
                .Include(t => t.IdTipoTelefonoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTelefono == id);
            if (telefonos == null)
            {
                return NotFound();
            }

            return View(telefonos);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonos = await _context.Telefonos.FindAsync(id);
            _context.Telefonos.Remove(telefonos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonosExists(int id)
        {
            return _context.Telefonos.Any(e => e.IdTelefono == id);
        }
    }
}
