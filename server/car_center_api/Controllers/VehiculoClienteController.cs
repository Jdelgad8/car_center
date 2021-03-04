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
    public class VehiculoClienteController : Controller
    {
        private readonly ModelContext _context;

        public VehiculoClienteController(ModelContext context)
        {
            _context = context;
        }

        // GET: VehiculoCliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculoCliente.ToListAsync());
        }

        // GET: VehiculoCliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoCliente = await _context.VehiculoCliente
                .FirstOrDefaultAsync(m => m.CodVeh == id);
            if (vehiculoCliente == null)
            {
                return NotFound();
            }

            return View(vehiculoCliente);
        }

        // GET: VehiculoCliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoCliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodVeh,CodCli")] VehiculoCliente vehiculoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculoCliente);
        }

        // GET: VehiculoCliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoCliente = await _context.VehiculoCliente.FindAsync(id);
            if (vehiculoCliente == null)
            {
                return NotFound();
            }
            return View(vehiculoCliente);
        }

        // POST: VehiculoCliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodVeh,CodCli")] VehiculoCliente vehiculoCliente)
        {
            if (id != vehiculoCliente.CodVeh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoClienteExists(vehiculoCliente.CodVeh))
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
            return View(vehiculoCliente);
        }

        // GET: VehiculoCliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculoCliente = await _context.VehiculoCliente
                .FirstOrDefaultAsync(m => m.CodVeh == id);
            if (vehiculoCliente == null)
            {
                return NotFound();
            }

            return View(vehiculoCliente);
        }

        // POST: VehiculoCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculoCliente = await _context.VehiculoCliente.FindAsync(id);
            _context.VehiculoCliente.Remove(vehiculoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoClienteExists(int id)
        {
            return _context.VehiculoCliente.Any(e => e.CodVeh == id);
        }
    }
}
