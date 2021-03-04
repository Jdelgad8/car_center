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
    public class EstVehiculoController : Controller
    {
        private readonly ModelContext _context;

        public EstVehiculoController(ModelContext context)
        {
            _context = context;
        }

        // GET: EstVehiculo
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.EstVehiculo.Include(e => e.CodVehNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: EstVehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estVehiculo = await _context.EstVehiculo
                .Include(e => e.CodVehNavigation)
                .FirstOrDefaultAsync(m => m.CodEstVeh == id);
            if (estVehiculo == null)
            {
                return NotFound();
            }

            return View(estVehiculo);
        }

        // GET: EstVehiculo/Create
        public IActionResult Create()
        {
            ViewData["CodVeh"] = new SelectList(_context.Vehiculo, "CodVeh", "Color");
            return View();
        }

        // POST: EstVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstVeh,CodVeh,Descripcion,UrlImg")] EstVehiculo estVehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estVehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodVeh"] = new SelectList(_context.Vehiculo, "CodVeh", "Color", estVehiculo.CodVeh);
            return View(estVehiculo);
        }

        // GET: EstVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estVehiculo = await _context.EstVehiculo.FindAsync(id);
            if (estVehiculo == null)
            {
                return NotFound();
            }
            ViewData["CodVeh"] = new SelectList(_context.Vehiculo, "CodVeh", "Color", estVehiculo.CodVeh);
            return View(estVehiculo);
        }

        // POST: EstVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodEstVeh,CodVeh,Descripcion,UrlImg")] EstVehiculo estVehiculo)
        {
            if (id != estVehiculo.CodEstVeh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estVehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstVehiculoExists(estVehiculo.CodEstVeh))
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
            ViewData["CodVeh"] = new SelectList(_context.Vehiculo, "CodVeh", "Color", estVehiculo.CodVeh);
            return View(estVehiculo);
        }

        // GET: EstVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estVehiculo = await _context.EstVehiculo
                .Include(e => e.CodVehNavigation)
                .FirstOrDefaultAsync(m => m.CodEstVeh == id);
            if (estVehiculo == null)
            {
                return NotFound();
            }

            return View(estVehiculo);
        }

        // POST: EstVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estVehiculo = await _context.EstVehiculo.FindAsync(id);
            _context.EstVehiculo.Remove(estVehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstVehiculoExists(int id)
        {
            return _context.EstVehiculo.Any(e => e.CodEstVeh == id);
        }
    }
}
