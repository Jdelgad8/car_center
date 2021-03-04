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
    public class DctoFacturaController : Controller
    {
        private readonly ModelContext _context;

        public DctoFacturaController(ModelContext context)
        {
            _context = context;
        }

        // GET: DctoFactura
        public async Task<IActionResult> Index()
        {
            return View(await _context.DctoFactura.ToListAsync());
        }

        // GET: DctoFactura/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dctoFactura = await _context.DctoFactura
                .FirstOrDefaultAsync(m => m.CodDcto == id);
            if (dctoFactura == null)
            {
                return NotFound();
            }

            return View(dctoFactura);
        }

        // GET: DctoFactura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DctoFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodDcto,VlrMinDcto,PorcDcto")] DctoFactura dctoFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dctoFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dctoFactura);
        }

        // GET: DctoFactura/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dctoFactura = await _context.DctoFactura.FindAsync(id);
            if (dctoFactura == null)
            {
                return NotFound();
            }
            return View(dctoFactura);
        }

        // POST: DctoFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodDcto,VlrMinDcto,PorcDcto")] DctoFactura dctoFactura)
        {
            if (id != dctoFactura.CodDcto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dctoFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DctoFacturaExists(dctoFactura.CodDcto))
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
            return View(dctoFactura);
        }

        // GET: DctoFactura/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dctoFactura = await _context.DctoFactura
                .FirstOrDefaultAsync(m => m.CodDcto == id);
            if (dctoFactura == null)
            {
                return NotFound();
            }

            return View(dctoFactura);
        }

        // POST: DctoFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var dctoFactura = await _context.DctoFactura.FindAsync(id);
            _context.DctoFactura.Remove(dctoFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DctoFacturaExists(byte id)
        {
            return _context.DctoFactura.Any(e => e.CodDcto == id);
        }
    }
}
