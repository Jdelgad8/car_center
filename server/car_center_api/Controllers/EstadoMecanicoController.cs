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
    public class EstadoMecanicoController : Controller
    {
        private readonly ModelContext _context;

        public EstadoMecanicoController(ModelContext context)
        {
            _context = context;
        }

        // GET: EstadoMecanico
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoMecanico.ToListAsync());
        }

        // GET: EstadoMecanico/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMecanico = await _context.EstadoMecanico
                .FirstOrDefaultAsync(m => m.CodEstMec == id);
            if (estadoMecanico == null)
            {
                return NotFound();
            }

            return View(estadoMecanico);
        }

        // GET: EstadoMecanico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoMecanico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstMec,Descripcion")] EstadoMecanico estadoMecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoMecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoMecanico);
        }

        // GET: EstadoMecanico/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMecanico = await _context.EstadoMecanico.FindAsync(id);
            if (estadoMecanico == null)
            {
                return NotFound();
            }
            return View(estadoMecanico);
        }

        // POST: EstadoMecanico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEstMec,Descripcion")] EstadoMecanico estadoMecanico)
        {
            if (id != estadoMecanico.CodEstMec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoMecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoMecanicoExists(estadoMecanico.CodEstMec))
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
            return View(estadoMecanico);
        }

        // GET: EstadoMecanico/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMecanico = await _context.EstadoMecanico
                .FirstOrDefaultAsync(m => m.CodEstMec == id);
            if (estadoMecanico == null)
            {
                return NotFound();
            }

            return View(estadoMecanico);
        }

        // POST: EstadoMecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estadoMecanico = await _context.EstadoMecanico.FindAsync(id);
            _context.EstadoMecanico.Remove(estadoMecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoMecanicoExists(string id)
        {
            return _context.EstadoMecanico.Any(e => e.CodEstMec == id);
        }
    }
}
