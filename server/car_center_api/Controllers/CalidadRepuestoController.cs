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
    public class CalidadRepuestoController : Controller
    {
        private readonly ModelContext _context;

        public CalidadRepuestoController(ModelContext context)
        {
            _context = context;
        }

        // GET: CalidadRepuestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CalidadRepuesto.ToListAsync());
        }

        // GET: CalidadRepuestoes/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calidadRepuesto = await _context.CalidadRepuesto
                .FirstOrDefaultAsync(m => m.CodCalRep == id);
            if (calidadRepuesto == null)
            {
                return NotFound();
            }

            return View(calidadRepuesto);
        }

        // GET: CalidadRepuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalidadRepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCalRep,Descripcion")] CalidadRepuesto calidadRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calidadRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calidadRepuesto);
        }

        // GET: CalidadRepuestoes/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calidadRepuesto = await _context.CalidadRepuesto.FindAsync(id);
            if (calidadRepuesto == null)
            {
                return NotFound();
            }
            return View(calidadRepuesto);
        }

        // POST: CalidadRepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodCalRep,Descripcion")] CalidadRepuesto calidadRepuesto)
        {
            if (id != calidadRepuesto.CodCalRep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calidadRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalidadRepuestoExists(calidadRepuesto.CodCalRep))
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
            return View(calidadRepuesto);
        }

        // GET: CalidadRepuestoes/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calidadRepuesto = await _context.CalidadRepuesto
                .FirstOrDefaultAsync(m => m.CodCalRep == id);
            if (calidadRepuesto == null)
            {
                return NotFound();
            }

            return View(calidadRepuesto);
        }

        // POST: CalidadRepuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var calidadRepuesto = await _context.CalidadRepuesto.FindAsync(id);
            _context.CalidadRepuesto.Remove(calidadRepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalidadRepuestoExists(byte id)
        {
            return _context.CalidadRepuesto.Any(e => e.CodCalRep == id);
        }
    }
}
