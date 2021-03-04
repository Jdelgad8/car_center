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
    public class TipoRepuestoController : Controller
    {
        private readonly ModelContext _context;

        public TipoRepuestoController(ModelContext context)
        {
            _context = context;
        }

        // GET: TipoRepuesto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoRepuesto.ToListAsync());
        }

        // GET: TipoRepuesto/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRepuesto = await _context.TipoRepuesto
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoRepuesto == null)
            {
                return NotFound();
            }

            return View(tipoRepuesto);
        }

        // GET: TipoRepuesto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoRepuesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTipo,Descripcion")] TipoRepuesto tipoRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoRepuesto);
        }

        // GET: TipoRepuesto/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRepuesto = await _context.TipoRepuesto.FindAsync(id);
            if (tipoRepuesto == null)
            {
                return NotFound();
            }
            return View(tipoRepuesto);
        }

        // POST: TipoRepuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodTipo,Descripcion")] TipoRepuesto tipoRepuesto)
        {
            if (id != tipoRepuesto.CodTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoRepuestoExists(tipoRepuesto.CodTipo))
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
            return View(tipoRepuesto);
        }

        // GET: TipoRepuesto/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoRepuesto = await _context.TipoRepuesto
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoRepuesto == null)
            {
                return NotFound();
            }

            return View(tipoRepuesto);
        }

        // POST: TipoRepuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var tipoRepuesto = await _context.TipoRepuesto.FindAsync(id);
            _context.TipoRepuesto.Remove(tipoRepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoRepuestoExists(byte id)
        {
            return _context.TipoRepuesto.Any(e => e.CodTipo == id);
        }
    }
}
