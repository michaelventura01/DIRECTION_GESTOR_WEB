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
    public class EmpleadosinstitucionesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EmpleadosinstitucionesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Empleadosinstituciones
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Empleadosinstituciones.Include(e => e.CodigoEmpleadoFkNavigation).Include(e => e.IdInstitucionFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Empleadosinstituciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosinstituciones = await _context.Empleadosinstituciones
                .Include(e => e.CodigoEmpleadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoInstitucion == id);
            if (empleadosinstituciones == null)
            {
                return NotFound();
            }

            return View(empleadosinstituciones);
        }

        // GET: Empleadosinstituciones/Create
        public IActionResult Create()
        {
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            return View();
        }

        // POST: Empleadosinstituciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleadoInstitucion,CodigoEmpleadoFk,FechaInicio,IdInstitucionFk")] Empleadosinstituciones empleadosinstituciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleadosinstituciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleadosinstituciones.CodigoEmpleadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", empleadosinstituciones.IdInstitucionFk);
            return View(empleadosinstituciones);
        }

        // GET: Empleadosinstituciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosinstituciones = await _context.Empleadosinstituciones.FindAsync(id);
            if (empleadosinstituciones == null)
            {
                return NotFound();
            }
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleadosinstituciones.CodigoEmpleadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", empleadosinstituciones.IdInstitucionFk);
            return View(empleadosinstituciones);
        }

        // POST: Empleadosinstituciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleadoInstitucion,CodigoEmpleadoFk,FechaInicio,IdInstitucionFk")] Empleadosinstituciones empleadosinstituciones)
        {
            if (id != empleadosinstituciones.IdEmpleadoInstitucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleadosinstituciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosinstitucionesExists(empleadosinstituciones.IdEmpleadoInstitucion))
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
            ViewData["CodigoEmpleadoFk"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleadosinstituciones.CodigoEmpleadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", empleadosinstituciones.IdInstitucionFk);
            return View(empleadosinstituciones);
        }

        // GET: Empleadosinstituciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleadosinstituciones = await _context.Empleadosinstituciones
                .Include(e => e.CodigoEmpleadoFkNavigation)
                .Include(e => e.IdInstitucionFkNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleadoInstitucion == id);
            if (empleadosinstituciones == null)
            {
                return NotFound();
            }

            return View(empleadosinstituciones);
        }

        // POST: Empleadosinstituciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleadosinstituciones = await _context.Empleadosinstituciones.FindAsync(id);
            _context.Empleadosinstituciones.Remove(empleadosinstituciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosinstitucionesExists(int id)
        {
            return _context.Empleadosinstituciones.Any(e => e.IdEmpleadoInstitucion == id);
        }
    }
}
