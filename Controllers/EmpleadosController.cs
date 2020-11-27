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
    public class EmpleadosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public EmpleadosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Empleados.Include(e => e.IdEstadoFkNavigation).Include(e => e.IdPersonaFkNavigation).Include(e => e.IdPuestoTrabajoFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdPersonaFkNavigation)
                .Include(e => e.IdPuestoTrabajoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas");
            ViewData["IdPuestoTrabajoFk"] = new SelectList(_context.Puestostrabajos, "IdPuestoTrabajo", "DescripcionPuestoTrabajo");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmpleado,SueldoEmpleado,FechaInicioEmpleado,IdPersonaFk,IdEstadoFk,IdPuestoTrabajoFk,IdInstitucionFk")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", empleados.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", empleados.IdPersonaFk);
            ViewData["IdPuestoTrabajoFk"] = new SelectList(_context.Puestostrabajos, "IdPuestoTrabajo", "DescripcionPuestoTrabajo", empleados.IdPuestoTrabajoFk);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", empleados.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", empleados.IdPersonaFk);
            ViewData["IdPuestoTrabajoFk"] = new SelectList(_context.Puestostrabajos, "IdPuestoTrabajo", "DescripcionPuestoTrabajo", empleados.IdPuestoTrabajoFk);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoEmpleado,SueldoEmpleado,FechaInicioEmpleado,IdPersonaFk,IdEstadoFk,IdPuestoTrabajoFk,IdInstitucionFk")] Empleados empleados)
        {
            if (id != empleados.CodigoEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.CodigoEmpleado))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", empleados.IdEstadoFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "NombrePersonas", empleados.IdPersonaFk);
            ViewData["IdPuestoTrabajoFk"] = new SelectList(_context.Puestostrabajos, "IdPuestoTrabajo", "DescripcionPuestoTrabajo", empleados.IdPuestoTrabajoFk);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.IdEstadoFkNavigation)
                .Include(e => e.IdPersonaFkNavigation)
                .Include(e => e.IdPuestoTrabajoFkNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(string id)
        {
            return _context.Empleados.Any(e => e.CodigoEmpleado == id);
        }
    }
}
