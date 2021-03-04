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
    public class FacturaEncaController : Controller
    {
        private readonly ModelContext _context;

        public FacturaEncaController(ModelContext context)
        {
            _context = context;
        }

        // GET: FacturaEnca
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.FacturaEnca.Include(f => f.CodCliNavigation).Include(f => f.CodEstFacNavigation).Include(f => f.CodMecNavigation).Include(f => f.CodPagoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: FacturaEnca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnca = await _context.FacturaEnca
                .Include(f => f.CodCliNavigation)
                .Include(f => f.CodEstFacNavigation)
                .Include(f => f.CodMecNavigation)
                .Include(f => f.CodPagoNavigation)
                .FirstOrDefaultAsync(m => m.CodFacEnc == id);
            if (facturaEnca == null)
            {
                return NotFound();
            }

            return View(facturaEnca);
        }

        // GET: FacturaEnca/Create
        public IActionResult Create()
        {
            ViewData["CodCli"] = new SelectList(_context.Cliente, "CodCli", "Direccion");
            ViewData["CodEstFac"] = new SelectList(_context.EstFactura, "CodEstFac", "CodEstFac");
            ViewData["CodMec"] = new SelectList(_context.Mecanico, "CodMec", "CodEstMec");
            ViewData["CodPago"] = new SelectList(_context.MedioPago, "CodPago", "Descripcion");
            return View();
        }

        // POST: FacturaEnca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodFacEnc,CodEstFac,CodCli,CodMec,CodPago,VlrDcto,FecFac,VlrTot,VlrIva")] FacturaEnca facturaEnca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaEnca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodCli"] = new SelectList(_context.Cliente, "CodCli", "Direccion", facturaEnca.CodCli);
            ViewData["CodEstFac"] = new SelectList(_context.EstFactura, "CodEstFac", "CodEstFac", facturaEnca.CodEstFac);
            ViewData["CodMec"] = new SelectList(_context.Mecanico, "CodMec", "CodEstMec", facturaEnca.CodMec);
            ViewData["CodPago"] = new SelectList(_context.MedioPago, "CodPago", "Descripcion", facturaEnca.CodPago);
            return View(facturaEnca);
        }

        // GET: FacturaEnca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnca = await _context.FacturaEnca.FindAsync(id);
            if (facturaEnca == null)
            {
                return NotFound();
            }
            ViewData["CodCli"] = new SelectList(_context.Cliente, "CodCli", "Direccion", facturaEnca.CodCli);
            ViewData["CodEstFac"] = new SelectList(_context.EstFactura, "CodEstFac", "CodEstFac", facturaEnca.CodEstFac);
            ViewData["CodMec"] = new SelectList(_context.Mecanico, "CodMec", "CodEstMec", facturaEnca.CodMec);
            ViewData["CodPago"] = new SelectList(_context.MedioPago, "CodPago", "Descripcion", facturaEnca.CodPago);
            return View(facturaEnca);
        }

        // POST: FacturaEnca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodFacEnc,CodEstFac,CodCli,CodMec,CodPago,VlrDcto,FecFac,VlrTot,VlrIva")] FacturaEnca facturaEnca)
        {
            if (id != facturaEnca.CodFacEnc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaEnca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaEncaExists(facturaEnca.CodFacEnc))
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
            ViewData["CodCli"] = new SelectList(_context.Cliente, "CodCli", "Direccion", facturaEnca.CodCli);
            ViewData["CodEstFac"] = new SelectList(_context.EstFactura, "CodEstFac", "CodEstFac", facturaEnca.CodEstFac);
            ViewData["CodMec"] = new SelectList(_context.Mecanico, "CodMec", "CodEstMec", facturaEnca.CodMec);
            ViewData["CodPago"] = new SelectList(_context.MedioPago, "CodPago", "Descripcion", facturaEnca.CodPago);
            return View(facturaEnca);
        }

        // GET: FacturaEnca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnca = await _context.FacturaEnca
                .Include(f => f.CodCliNavigation)
                .Include(f => f.CodEstFacNavigation)
                .Include(f => f.CodMecNavigation)
                .Include(f => f.CodPagoNavigation)
                .FirstOrDefaultAsync(m => m.CodFacEnc == id);
            if (facturaEnca == null)
            {
                return NotFound();
            }

            return View(facturaEnca);
        }

        // POST: FacturaEnca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaEnca = await _context.FacturaEnca.FindAsync(id);
            _context.FacturaEnca.Remove(facturaEnca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaEncaExists(int id)
        {
            return _context.FacturaEnca.Any(e => e.CodFacEnc == id);
        }
    }
}
