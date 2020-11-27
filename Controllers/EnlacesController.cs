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
    public class EnlacesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EnlacesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Enlaces
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Enlaces.Include(e => e.IdEstadoFkNavigation).Include(e => e.IdInstitucionFkNavigation).Include(e => e.IdRolFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Enlaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enlaces = await _context.Enlaces
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .Include(e => e.IdRolFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEnlace == id);
            if (enlaces == null)
            {
                return NotFound();
            }

            return View(enlaces);
        }

        // GET: Enlaces/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol");
            return View();
        }

        // POST: Enlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnlace,DescripcionEnlace,UrlEnlace,IdEstadoFk,IdRolFk,IdInstitucionFk")] Enlaces enlaces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enlaces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", enlaces.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", enlaces.IdInstitucionFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", enlaces.IdRolFk);
            return View(enlaces);
        }

        // GET: Enlaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enlaces = await _context.Enlaces.FindAsync(id);
            if (enlaces == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", enlaces.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", enlaces.IdInstitucionFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", enlaces.IdRolFk);
            return View(enlaces);
        }

        // POST: Enlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnlace,DescripcionEnlace,UrlEnlace,IdEstadoFk,IdRolFk,IdInstitucionFk")] Enlaces enlaces)
        {
            if (id != enlaces.IdEnlace)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enlaces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnlacesExists(enlaces.IdEnlace))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", enlaces.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", enlaces.IdInstitucionFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", enlaces.IdRolFk);
            return View(enlaces);
        }

        // GET: Enlaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enlaces = await _context.Enlaces
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .Include(e => e.IdRolFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEnlace == id);
            if (enlaces == null)
            {
                return NotFound();
            }

            return View(enlaces);
        }

        // POST: Enlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enlaces = await _context.Enlaces.FindAsync(id);
            _context.Enlaces.Remove(enlaces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnlacesExists(int id)
        {
            return _context.Enlaces.Any(e => e.IdEnlace == id);
        }
    }
}
