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
    public class AsignaturasempleadosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public AsignaturasempleadosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Asignaturasempleados
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Asignaturasempleados.Include(a => a.CodigoEmpleadoFkNavigation).Include(a => a.IdEstadoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Asignaturasempleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleados = await _context.Asignaturasempleados
                .Include(a => a.CodigoEmpleadoFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaEmpleado == id);
            if (asignaturasempleados == null)
            {
                return NotFound();
            }

            return View(asignaturasempleados);
        }

        // GET: Asignaturasempleados/Create
        public IActionResult Create()
        {
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado");
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Asignaturasempleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignaturaEmpleado,CodigoEmpleadoFk,IdEstadoFk")] Asignaturasempleados asignaturasempleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturasempleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", asignaturasempleados.CodigoEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleados.IdEstadoFk);
            return View(asignaturasempleados);
        }

        // GET: Asignaturasempleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleados = await _context.Asignaturasempleados.FindAsync(id);
            if (asignaturasempleados == null)
            {
                return NotFound();
            }
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", asignaturasempleados.CodigoEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleados.IdEstadoFk);
            return View(asignaturasempleados);
        }

        // POST: Asignaturasempleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignaturaEmpleado,CodigoEmpleadoFk,IdEstadoFk")] Asignaturasempleados asignaturasempleados)
        {
            if (id != asignaturasempleados.IdAsignaturaEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturasempleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasempleadosExists(asignaturasempleados.IdAsignaturaEmpleado))
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
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", asignaturasempleados.CodigoEmpleadoFk);
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", asignaturasempleados.IdEstadoFk);
            return View(asignaturasempleados);
        }

        // GET: Asignaturasempleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasempleados = await _context.Asignaturasempleados
                .Include(a => a.CodigoEmpleadoFkNavigation)
                .Include(a => a.IdEstadoFkNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignaturaEmpleado == id);
            if (asignaturasempleados == null)
            {
                return NotFound();
            }

            return View(asignaturasempleados);
        }

        // POST: Asignaturasempleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturasempleados = await _context.Asignaturasempleados.FindAsync(id);
            _context.Asignaturasempleados.Remove(asignaturasempleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasempleadosExists(int id)
        {
            return _context.Asignaturasempleados.Any(e => e.IdAsignaturaEmpleado == id);
        }
    }
}
