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
    public class FacturaDetaController : Controller
    {
        private readonly ModelContext _context;

        public FacturaDetaController(ModelContext context)
        {
            _context = context;
        }

        // GET: FacturaDeta
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.FacturaDeta.Include(f => f.CodFacEncNavigation).Include(f => f.CodSolSerRepNavigation).Include(f => f.CodSolicNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: FacturaDeta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDeta = await _context.FacturaDeta
                .Include(f => f.CodFacEncNavigation)
                .Include(f => f.CodSolSerRepNavigation)
                .Include(f => f.CodSolicNavigation)
                .FirstOrDefaultAsync(m => m.CodFacDet == id);
            if (facturaDeta == null)
            {
                return NotFound();
            }

            return View(facturaDeta);
        }

        // GET: FacturaDeta/Create
        public IActionResult Create()
        {
            ViewData["CodFacEnc"] = new SelectList(_context.FacturaEnca, "CodFacEnc", "CodEstFac");
            ViewData["CodSolSerRep"] = new SelectList(_context.SolicitudSerRepuesto, "CodSolSerRep", "CodSolSerRep");
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic");
            return View();
        }

        // POST: FacturaDeta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodFacDet,CodFacEnc,CodSolic,CodSolSerRep,VlrSub")] FacturaDeta facturaDeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaDeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodFacEnc"] = new SelectList(_context.FacturaEnca, "CodFacEnc", "CodEstFac", facturaDeta.CodFacEnc);
            ViewData["CodSolSerRep"] = new SelectList(_context.SolicitudSerRepuesto, "CodSolSerRep", "CodSolSerRep", facturaDeta.CodSolSerRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", facturaDeta.CodSolic);
            return View(facturaDeta);
        }

        // GET: FacturaDeta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDeta = await _context.FacturaDeta.FindAsync(id);
            if (facturaDeta == null)
            {
                return NotFound();
            }
            ViewData["CodFacEnc"] = new SelectList(_context.FacturaEnca, "CodFacEnc", "CodEstFac", facturaDeta.CodFacEnc);
            ViewData["CodSolSerRep"] = new SelectList(_context.SolicitudSerRepuesto, "CodSolSerRep", "CodSolSerRep", facturaDeta.CodSolSerRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", facturaDeta.CodSolic);
            return View(facturaDeta);
        }

        // POST: FacturaDeta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodFacDet,CodFacEnc,CodSolic,CodSolSerRep,VlrSub")] FacturaDeta facturaDeta)
        {
            if (id != facturaDeta.CodFacDet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaDeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetaExists(facturaDeta.CodFacDet))
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
            ViewData["CodFacEnc"] = new SelectList(_context.FacturaEnca, "CodFacEnc", "CodEstFac", facturaDeta.CodFacEnc);
            ViewData["CodSolSerRep"] = new SelectList(_context.SolicitudSerRepuesto, "CodSolSerRep", "CodSolSerRep", facturaDeta.CodSolSerRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", facturaDeta.CodSolic);
            return View(facturaDeta);
        }

        // GET: FacturaDeta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDeta = await _context.FacturaDeta
                .Include(f => f.CodFacEncNavigation)
                .Include(f => f.CodSolSerRepNavigation)
                .Include(f => f.CodSolicNavigation)
                .FirstOrDefaultAsync(m => m.CodFacDet == id);
            if (facturaDeta == null)
            {
                return NotFound();
            }

            return View(facturaDeta);
        }

        // POST: FacturaDeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDeta = await _context.FacturaDeta.FindAsync(id);
            _context.FacturaDeta.Remove(facturaDeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetaExists(int id)
        {
            return _context.FacturaDeta.Any(e => e.CodFacDet == id);
        }
    }
}
