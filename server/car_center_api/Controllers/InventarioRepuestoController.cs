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
    public class InventarioRepuestoController : Controller
    {
        private readonly ModelContext _context;

        public InventarioRepuestoController(ModelContext context)
        {
            _context = context;
        }

        // GET: InventarioRepuestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioRepuesto.ToListAsync());
        }

        // GET: InventarioRepuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioRepuesto = await _context.InventarioRepuesto
                .FirstOrDefaultAsync(m => m.CodRep == id);
            if (inventarioRepuesto == null)
            {
                return NotFound();
            }

            return View(inventarioRepuesto);
        }

        // GET: InventarioRepuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioRepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodRep,CodTaller,Cantidad,FecAct")] InventarioRepuesto inventarioRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioRepuesto);
        }

        // GET: InventarioRepuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioRepuesto = await _context.InventarioRepuesto.FindAsync(id);
            if (inventarioRepuesto == null)
            {
                return NotFound();
            }
            return View(inventarioRepuesto);
        }

        // POST: InventarioRepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodRep,CodTaller,Cantidad,FecAct")] InventarioRepuesto inventarioRepuesto)
        {
            if (id != inventarioRepuesto.CodRep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioRepuestoExists(inventarioRepuesto.CodRep))
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
            return View(inventarioRepuesto);
        }

        // GET: InventarioRepuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioRepuesto = await _context.InventarioRepuesto
                .FirstOrDefaultAsync(m => m.CodRep == id);
            if (inventarioRepuesto == null)
            {
                return NotFound();
            }

            return View(inventarioRepuesto);
        }

        // POST: InventarioRepuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioRepuesto = await _context.InventarioRepuesto.FindAsync(id);
            _context.InventarioRepuesto.Remove(inventarioRepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioRepuestoExists(int id)
        {
            return _context.InventarioRepuesto.Any(e => e.CodRep == id);
        }
    }
}
