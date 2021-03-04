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
    public class EstFacturaController : Controller
    {
        private readonly ModelContext _context;

        public EstFacturaController(ModelContext context)
        {
            _context = context;
        }

        // GET: EstFactura
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstFactura.ToListAsync());
        }

        // GET: EstFactura/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estFactura = await _context.EstFactura
                .FirstOrDefaultAsync(m => m.CodEstFac == id);
            if (estFactura == null)
            {
                return NotFound();
            }

            return View(estFactura);
        }

        // GET: EstFactura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstFac,Descripcion")] EstFactura estFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estFactura);
        }

        // GET: EstFactura/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estFactura = await _context.EstFactura.FindAsync(id);
            if (estFactura == null)
            {
                return NotFound();
            }
            return View(estFactura);
        }

        // POST: EstFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEstFac,Descripcion")] EstFactura estFactura)
        {
            if (id != estFactura.CodEstFac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstFacturaExists(estFactura.CodEstFac))
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
            return View(estFactura);
        }

        // GET: EstFactura/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estFactura = await _context.EstFactura
                .FirstOrDefaultAsync(m => m.CodEstFac == id);
            if (estFactura == null)
            {
                return NotFound();
            }

            return View(estFactura);
        }

        // POST: EstFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estFactura = await _context.EstFactura.FindAsync(id);
            _context.EstFactura.Remove(estFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstFacturaExists(string id)
        {
            return _context.EstFactura.Any(e => e.CodEstFac == id);
        }
    }
}
