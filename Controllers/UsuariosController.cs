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
    public class UsuariosController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public UsuariosController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Usuarios.Include(u => u.IdEstadoFkNavigation).Include(u => u.IdInstitucionFkNavigation).Include(u => u.IdPersonaFkNavigation).Include(u => u.IdRolFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.IdEstadoFkNavigation)
                .Include(u => u.IdInstitucionFkNavigation)
                .Include(u => u.IdPersonaFkNavigation)
                .Include(u => u.IdRolFkNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas");
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NameUsuario,PasswordUsuario,IdEstadoFk,IdRolFk,IdPersonaFk,IdInstitucionFk")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", usuarios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", usuarios.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", usuarios.IdPersonaFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", usuarios.IdRolFk);
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", usuarios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", usuarios.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", usuarios.IdPersonaFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", usuarios.IdRolFk);
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NameUsuario,PasswordUsuario,IdEstadoFk,IdRolFk,IdPersonaFk,IdInstitucionFk")] Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.IdUsuario))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", usuarios.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", usuarios.IdInstitucionFk);
            ViewData["IdPersonaFk"] = new SelectList(_context.Personas, "IdPersona", "ApellidoPersonas", usuarios.IdPersonaFk);
            ViewData["IdRolFk"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", usuarios.IdRolFk);
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = await _context.Usuarios
                .Include(u => u.IdEstadoFkNavigation)
                .Include(u => u.IdInstitucionFkNavigation)
                .Include(u => u.IdPersonaFkNavigation)
                .Include(u => u.IdRolFkNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
