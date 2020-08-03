using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSI.Web.Models;

namespace CMSI.Web.Controllers
{
    public class ProfesionalesController : Controller
    {
        private readonly DataContext _context;

        public ProfesionalesController(DataContext context)
        {
            _context = context;
        }

        // GET: Profesionales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesionales.ToListAsync());
        }

        // GET: Profesionales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesionales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                var dbObjectIdentificacion = await _context.Profesionales.FirstOrDefaultAsync(x => x.NroIdentificacion == profesional.NroIdentificacion);

                if (dbObjectIdentificacion == null)
                {
                    profesional.Id = Guid.NewGuid();
                    profesional.FechaCreacion = DateTime.Now;
                    profesional.FechaModificacion = DateTime.Now;

                    _context.Add(profesional);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("NroIdentificacion", "Ya existe un registro con el mismo valor.");
            }
            return View(profesional);
        }

        // GET: Profesionales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            return View(profesional);
        }

        // POST: Profesionales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Profesional profesional)
        {
            if (id != profesional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbObjectIdentificacion = await _context.Profesionales.FirstOrDefaultAsync(x => x.Id != id && x.NroIdentificacion == profesional.NroIdentificacion);

                if (dbObjectIdentificacion == null)
                {
                    try
                    {
                        profesional.FechaModificacion = DateTime.Now;

                        _context.Update(profesional);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProfesionalExists(profesional.Id))
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

                ModelState.AddModelError("NroIdentificacion", "Ya existe un registro con el mismo valor.");
            }
            return View(profesional);
        }

        // GET: Profesionales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            _context.Profesionales.Remove(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(Guid id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }
    }
}
