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
    public class AulasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public AulasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Aulas.Include(a => a.IdEdificioFkNavigation).Include(a => a.IdEstadoFkNavigation).Include(a => a.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .Include(a => a.IdEdificioFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAula == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            ViewData["IdEdificioFk"] = new SelectList(_context.Edificios, "IdEdificio", "DescripcionEdificio");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAula,DescripcionAula,IdEstadoFk,IdEdificioFk,IdInstitucionFk")] Aulas aulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEdificioFk"] = new SelectList(_context.Edificios, "IdEdificio", "DescripcionEdificio", aulas.IdEdificioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", aulas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", aulas.IdInstitucionFk);
            return View(aulas);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas.FindAsync(id);
            if (aulas == null)
            {
                return NotFound();
            }
            ViewData["IdEdificioFk"] = new SelectList(_context.Edificios, "IdEdificio", "DescripcionEdificio", aulas.IdEdificioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", aulas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", aulas.IdInstitucionFk);
            return View(aulas);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAula,DescripcionAula,IdEstadoFk,IdEdificioFk,IdInstitucionFk")] Aulas aulas)
        {
            if (id != aulas.IdAula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulasExists(aulas.IdAula))
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
            ViewData["IdEdificioFk"] = new SelectList(_context.Edificios, "IdEdificio", "DescripcionEdificio", aulas.IdEdificioFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", aulas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", aulas.IdInstitucionFk);
            return View(aulas);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .Include(a => a.IdEdificioFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .Include(a => a.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAula == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aulas = await _context.Aulas.FindAsync(id);
            _context.Aulas.Remove(aulas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulasExists(int id)
        {
            return _context.Aulas.Any(e => e.IdAula == id);
        }
    }
}
