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
    public class TallerController : Controller
    {
        private readonly ModelContext _context;

        public TallerController(ModelContext context)
        {
            _context = context;
        }

        // GET: Taller
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Taller.Include(t => t.CodZonaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Taller/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller
                .Include(t => t.CodZonaNavigation)
                .FirstOrDefaultAsync(m => m.CodTaller == id);
            if (taller == null)
            {
                return NotFound();
            }

            return View(taller);
        }

        // GET: Taller/Create
        public IActionResult Create()
        {
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona");
            return View();
        }

        // POST: Taller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTaller,CodZona,NroCel,Direccion,FecReg")] Taller taller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", taller.CodZona);
            return View(taller);
        }

        // GET: Taller/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller.FindAsync(id);
            if (taller == null)
            {
                return NotFound();
            }
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", taller.CodZona);
            return View(taller);
        }

        // POST: Taller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTaller,CodZona,NroCel,Direccion,FecReg")] Taller taller)
        {
            if (id != taller.CodTaller)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TallerExists(taller.CodTaller))
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
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", taller.CodZona);
            return View(taller);
        }

        // GET: Taller/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taller = await _context.Taller
                .Include(t => t.CodZonaNavigation)
                .FirstOrDefaultAsync(m => m.CodTaller == id);
            if (taller == null)
            {
                return NotFound();
            }

            return View(taller);
        }

        // POST: Taller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taller = await _context.Taller.FindAsync(id);
            _context.Taller.Remove(taller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TallerExists(int id)
        {
            return _context.Taller.Any(e => e.CodTaller == id);
        }
    }
}
