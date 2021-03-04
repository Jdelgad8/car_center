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
    public class CiudadController : Controller
    {
        private readonly ModelContext _context;

        public CiudadController(ModelContext context)
        {
            _context = context;
        }

        // GET: Ciudads
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Ciudad.Include(c => c.CodDepNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Ciudads/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.CodDepNavigation)
                .FirstOrDefaultAsync(m => m.CodCiu == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudads/Create
        public IActionResult Create()
        {
            ViewData["CodDep"] = new SelectList(_context.Departamento, "CodDep", "Descripcion");
            return View();
        }

        // POST: Ciudads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCiu,CodDep,Descripcion")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodDep"] = new SelectList(_context.Departamento, "CodDep", "Descripcion", ciudad.CodDep);
            return View(ciudad);
        }

        // GET: Ciudads/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            ViewData["CodDep"] = new SelectList(_context.Departamento, "CodDep", "Descripcion", ciudad.CodDep);
            return View(ciudad);
        }

        // POST: Ciudads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodCiu,CodDep,Descripcion")] Ciudad ciudad)
        {
            if (id != ciudad.CodCiu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadExists(ciudad.CodCiu))
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
            ViewData["CodDep"] = new SelectList(_context.Departamento, "CodDep", "Descripcion", ciudad.CodDep);
            return View(ciudad);
        }

        // GET: Ciudads/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .Include(c => c.CodDepNavigation)
                .FirstOrDefaultAsync(m => m.CodCiu == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(byte id)
        {
            return _context.Ciudad.Any(e => e.CodCiu == id);
        }
    }
}
