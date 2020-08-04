using CMSI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMSI.Web.Controllers
{
    public class ProcedimientosController : Controller
    {
        private readonly DataContext _context;

        public ProcedimientosController(DataContext context)
        {
            _context = context;
        }

        // GET: Procedimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procedimientos.ToListAsync());
        }

        // GET: Procedimientos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            return View(procedimiento);
        }

        // GET: Procedimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procedimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                var dbObjectCodigo = await _context.Procedimientos.FirstOrDefaultAsync(x => x.Codigo == procedimiento.Codigo);
                var dbObjectNombre = await _context.Procedimientos.FirstOrDefaultAsync(x => x.Nombre == procedimiento.Nombre);

                if (dbObjectCodigo == null && dbObjectNombre == null)
                {

                    procedimiento.Id = Guid.NewGuid();
                    procedimiento.FechaCreacion = DateTime.Now;
                    procedimiento.FechaModificacion = DateTime.Now;

                    _context.Add(procedimiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(dbObjectCodigo == null ?
                    "Nombre" : "Codigo",
                    "Ya existe un registro con el mismo valor.");
            }
            return View(procedimiento);
        }

        // GET: Procedimientos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimientos.FindAsync(id);
            if (procedimiento == null)
            {
                return NotFound();
            }
            return View(procedimiento);
        }

        // POST: Procedimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Procedimiento procedimiento)
        {
            if (id != procedimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbObjectCodigo = await _context.Procedimientos.FirstOrDefaultAsync(x => x.Id != id && x.Codigo == procedimiento.Codigo);
                var dbObjectNombre = await _context.Procedimientos.FirstOrDefaultAsync(x => x.Id != id && x.Nombre == procedimiento.Nombre);

                if (dbObjectCodigo == null && dbObjectNombre == null)
                {
                    try
                    {
                        procedimiento.FechaModificacion = DateTime.Now;

                        _context.Update(procedimiento);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProcedimientoExists(procedimiento.Id))
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

                ModelState.AddModelError(dbObjectCodigo == null ?
                    "Nombre" : "Codigo",
                    "Ya existe un registro con el mismo valor.");
            }
            return View(procedimiento);
        }

        // GET: Procedimientos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procedimiento = await _context.Procedimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimiento == null)
            {
                return NotFound();
            }

            return View(procedimiento);
        }

        // POST: Procedimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var procedimiento = await _context.Procedimientos.FindAsync(id);
            _context.Procedimientos.Remove(procedimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimientoExists(Guid id)
        {
            return _context.Procedimientos.Any(e => e.Id == id);
        }
    }
}
