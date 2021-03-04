using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using car_center_api.Models;

namespace car_center_api.Controllers
{
    public class RepuestoController : Controller
    {
        private readonly ModelContext _context;

        public RepuestoController(ModelContext context)
        {
            _context = context;
        }

        // GET: Repuesto
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Repuesto.Include(r => r.CodCalRepNavigation).Include(r => r.CodTipoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Repuesto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto
                .Include(r => r.CodCalRepNavigation)
                .Include(r => r.CodTipoNavigation)
                .FirstOrDefaultAsync(m => m.CodRep == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // GET: Repuesto/Create
        public IActionResult Create()
        {
            ViewData["CodCalRep"] = new SelectList(_context.CalidadRepuesto, "CodCalRep", "Descripcion");
            ViewData["CodTipo"] = new SelectList(_context.TipoRepuesto, "CodTipo", "Descripcion");
            return View();
        }

        // POST: Repuesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodRep,CodTipo,CodCalRep,NomRep,VlrRep")] Repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCalRep"] = new SelectList(_context.CalidadRepuesto, "CodCalRep", "Descripcion", repuesto.CodCalRep);
            ViewData["CodTipo"] = new SelectList(_context.TipoRepuesto, "CodTipo", "Descripcion", repuesto.CodTipo);
            return View(repuesto);
        }

        // GET: Repuesto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto.FindAsync(id);
            if (repuesto == null)
            {
                return NotFound();
            }
            ViewData["CodCalRep"] = new SelectList(_context.CalidadRepuesto, "CodCalRep", "Descripcion", repuesto.CodCalRep);
            ViewData["CodTipo"] = new SelectList(_context.TipoRepuesto, "CodTipo", "Descripcion", repuesto.CodTipo);
            return View(repuesto);
        }

        // POST: Repuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodRep,CodTipo,CodCalRep,NomRep,VlrRep")] Repuesto repuesto)
        {
            if (id != repuesto.CodRep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepuestoExists(repuesto.CodRep))
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
            ViewData["CodCalRep"] = new SelectList(_context.CalidadRepuesto, "CodCalRep", "Descripcion", repuesto.CodCalRep);
            ViewData["CodTipo"] = new SelectList(_context.TipoRepuesto, "CodTipo", "Descripcion", repuesto.CodTipo);
            return View(repuesto);
        }

        // GET: Repuesto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto
                .Include(r => r.CodCalRepNavigation)
                .Include(r => r.CodTipoNavigation)
                .FirstOrDefaultAsync(m => m.CodRep == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // POST: Repuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repuesto = await _context.Repuesto.FindAsync(id);
            _context.Repuesto.Remove(repuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepuestoExists(int id)
        {
            return _context.Repuesto.Any(e => e.CodRep == id);
        }
    }
}
