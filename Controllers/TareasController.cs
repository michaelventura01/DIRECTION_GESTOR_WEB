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
    public class TareasController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public TareasController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Tareas.Include(t => t.IdEstadoFkNavigation).Include(t => t.IdInstitucionFkNavigation).Include(t => t.IdPrioridadFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Tareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.IdEstadoFkNavigation)
                .Include(t => t.IdInstitucionFkNavigation)
                .Include(t => t.IdPrioridadFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTarea == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // GET: Tareas/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPrioridadFk"] = new SelectList(_context.Prioridades, "IdPrioridad", "DescripcionPrioridad");
            return View();
        }

        // POST: Tareas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarea,TituloTarea,DescripcionTarea,FechaTarea,HoraTarea,IdEstadoFk,IdPrioridadFk,IdInstitucionFk")] Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tareas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tareas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", tareas.IdInstitucionFk);
            ViewData["IdPrioridadFk"] = new SelectList(_context.Prioridades, "IdPrioridad", "DescripcionPrioridad", tareas.IdPrioridadFk);
            return View(tareas);
        }

        // GET: Tareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas.FindAsync(id);
            if (tareas == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tareas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", tareas.IdInstitucionFk);
            ViewData["IdPrioridadFk"] = new SelectList(_context.Prioridades, "IdPrioridad", "DescripcionPrioridad", tareas.IdPrioridadFk);
            return View(tareas);
        }

        // POST: Tareas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarea,TituloTarea,DescripcionTarea,FechaTarea,HoraTarea,IdEstadoFk,IdPrioridadFk,IdInstitucionFk")] Tareas tareas)
        {
            if (id != tareas.IdTarea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tareas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareasExists(tareas.IdTarea))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", tareas.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", tareas.IdInstitucionFk);
            ViewData["IdPrioridadFk"] = new SelectList(_context.Prioridades, "IdPrioridad", "DescripcionPrioridad", tareas.IdPrioridadFk);
            return View(tareas);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareas = await _context.Tareas
                .Include(t => t.IdEstadoFkNavigation)
                .Include(t => t.IdInstitucionFkNavigation)
                .Include(t => t.IdPrioridadFkNavigation)
                .FirstOrDefaultAsync(m => m.IdTarea == id);
            if (tareas == null)
            {
                return NotFound();
            }

            return View(tareas);
        }

        // POST: Tareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tareas = await _context.Tareas.FindAsync(id);
            _context.Tareas.Remove(tareas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareasExists(int id)
        {
            return _context.Tareas.Any(e => e.IdTarea == id);
        }
    }
}
