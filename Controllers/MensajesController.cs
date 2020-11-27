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
    public class MensajesController : Controller
    {
        private readonly DB_DIRECTIONGESTORContext _context;

        public MensajesController(DB_DIRECTIONGESTORContext context)
        {
            _context = context;
        }

        // GET: Mensajes
        public async Task<IActionResult> Index()
        {
            var dB_DIRECTIONGESTORContext = _context.Mensajes.Include(m => m.IdEstadoFkNavigation).Include(m => m.IdInstitucionFkNavigation).Include(m => m.IdUsuarioEmisorFkNavigation).Include(m => m.IdUsuarioReceptorFkNavigation);
            return View(await dB_DIRECTIONGESTORContext.ToListAsync());
        }

        // GET: Mensajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _context.Mensajes
                .Include(m => m.IdEstadoFkNavigation)
                .Include(m => m.IdInstitucionFkNavigation)
                .Include(m => m.IdUsuarioEmisorFkNavigation)
                .Include(m => m.IdUsuarioReceptorFkNavigation)
                .FirstOrDefaultAsync(m => m.IdMensaje == id);
            if (mensajes == null)
            {
                return NotFound();
            }

            return View(mensajes);
        }

        // GET: Mensajes/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado");
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion");
            ViewData["IdUsuarioEmisorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario");
            ViewData["IdUsuarioReceptorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario");
            return View();
        }

        // POST: Mensajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMensaje,TituloMensaje,DescripcionMensaje,IdUsuarioEmisorFk,IdUsuarioReceptorFk,IdEstadoFk,IdInstitucionFk")] Mensajes mensajes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensajes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", mensajes.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", mensajes.IdInstitucionFk);
            ViewData["IdUsuarioEmisorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioEmisorFk);
            ViewData["IdUsuarioReceptorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioReceptorFk);
            return View(mensajes);
        }

        // GET: Mensajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _context.Mensajes.FindAsync(id);
            if (mensajes == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", mensajes.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", mensajes.IdInstitucionFk);
            ViewData["IdUsuarioEmisorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioEmisorFk);
            ViewData["IdUsuarioReceptorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioReceptorFk);
            return View(mensajes);
        }

        // POST: Mensajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMensaje,TituloMensaje,DescripcionMensaje,IdUsuarioEmisorFk,IdUsuarioReceptorFk,IdEstadoFk,IdInstitucionFk")] Mensajes mensajes)
        {
            if (id != mensajes.IdMensaje)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensajes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajesExists(mensajes.IdMensaje))
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
            ViewData["IdEstadoFk"] = new SelectList(_context.Estados, "IdEstado", "DescripcionEstado", mensajes.IdEstadoFk);
            ViewData["IdInstitucionFk"] = new SelectList(_context.Instituciones, "IdInstitucion", "DescripcionInstitucion", mensajes.IdInstitucionFk);
            ViewData["IdUsuarioEmisorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioEmisorFk);
            ViewData["IdUsuarioReceptorFk"] = new SelectList(_context.Usuarios, "IdUsuario", "NameUsuario", mensajes.IdUsuarioReceptorFk);
            return View(mensajes);
        }

        // GET: Mensajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensajes = await _context.Mensajes
                .Include(m => m.IdEstadoFkNavigation)
                .Include(m => m.IdInstitucionFkNavigation)
                .Include(m => m.IdUsuarioEmisorFkNavigation)
                .Include(m => m.IdUsuarioReceptorFkNavigation)
                .FirstOrDefaultAsync(m => m.IdMensaje == id);
            if (mensajes == null)
            {
                return NotFound();
            }

            return View(mensajes);
        }

        // POST: Mensajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensajes = await _context.Mensajes.FindAsync(id);
            _context.Mensajes.Remove(mensajes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajesExists(int id)
        {
            return _context.Mensajes.Any(e => e.IdMensaje == id);
        }
    }
}
