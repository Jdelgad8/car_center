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
    public class MedioPagoController : Controller
    {
        private readonly ModelContext _context;

        public MedioPagoController(ModelContext context)
        {
            _context = context;
        }

        // GET: MedioPago
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedioPago.ToListAsync());
        }

        // GET: MedioPago/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MedioPago
                .FirstOrDefaultAsync(m => m.CodPago == id);
            if (medioPago == null)
            {
                return NotFound();
            }

            return View(medioPago);
        }

        // GET: MedioPago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedioPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodPago,Descripcion")] MedioPago medioPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medioPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medioPago);
        }

        // GET: MedioPago/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MedioPago.FindAsync(id);
            if (medioPago == null)
            {
                return NotFound();
            }
            return View(medioPago);
        }

        // POST: MedioPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodPago,Descripcion")] MedioPago medioPago)
        {
            if (id != medioPago.CodPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medioPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedioPagoExists(medioPago.CodPago))
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
            return View(medioPago);
        }

        // GET: MedioPago/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medioPago = await _context.MedioPago
                .FirstOrDefaultAsync(m => m.CodPago == id);
            if (medioPago == null)
            {
                return NotFound();
            }

            return View(medioPago);
        }

        // POST: MedioPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var medioPago = await _context.MedioPago.FindAsync(id);
            _context.MedioPago.Remove(medioPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedioPagoExists(byte id)
        {
            return _context.MedioPago.Any(e => e.CodPago == id);
        }
    }
}
