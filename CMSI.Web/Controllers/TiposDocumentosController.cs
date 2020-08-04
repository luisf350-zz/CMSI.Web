using CMSI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMSI.Web.Controllers
{
    public class TiposDocumentosController : Controller
    {
        private readonly DataContext _context;

        public TiposDocumentosController(DataContext context)
        {
            _context = context;
        }

        // GET: TiposDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumentos.ToListAsync());
        }

        // GET: TiposDocumentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TiposDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                var dbObjectNombre = await _context.Procedimientos
                    .FirstOrDefaultAsync(x => x.Nombre == tipoDocumento.Nombre);

                if (dbObjectNombre == null)
                {
                    tipoDocumento.Id = Guid.NewGuid();
                    tipoDocumento.FechaModificacion = DateTime.Now;
                    tipoDocumento.FechaCreacion = DateTime.Now;

                    _context.Add(tipoDocumento);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Nombre", "Ya existe un registro con el mismo valor.");

            }
            return View(tipoDocumento);
        }

        // GET: TiposDocumentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TiposDocumentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbObjectNombre = await _context.Procedimientos
                    .FirstOrDefaultAsync(x => x.Id != id && x.Nombre == tipoDocumento.Nombre);

                if (dbObjectNombre == null)
                {
                    try
                    {
                        tipoDocumento.FechaModificacion = DateTime.Now;
                        _context.Update(tipoDocumento);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TipoDocumentoExists(tipoDocumento.Id))
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

                ModelState.AddModelError("Nombre", "Ya existe un registro con el mismo valor.");
            }
            return View(tipoDocumento);
        }

        // GET: TiposDocumentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            _context.TipoDocumentos.Remove(tipoDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(Guid id)
        {
            return _context.TipoDocumentos.Any(e => e.Id == id);
        }
    }
}
