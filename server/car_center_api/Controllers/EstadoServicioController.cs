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
    public class EstadoServicioController : Controller
    {
        private readonly ModelContext _context;

        public EstadoServicioController(ModelContext context)
        {
            _context = context;
        }

        // GET: EstadoServicio
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoServicio.ToListAsync());
        }

        // GET: EstadoServicio/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoServicio = await _context.EstadoServicio
                .FirstOrDefaultAsync(m => m.CodEstServ == id);
            if (estadoServicio == null)
            {
                return NotFound();
            }

            return View(estadoServicio);
        }

        // GET: EstadoServicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoServicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEstServ,Descripcion")] EstadoServicio estadoServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoServicio);
        }

        // GET: EstadoServicio/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoServicio = await _context.EstadoServicio.FindAsync(id);
            if (estadoServicio == null)
            {
                return NotFound();
            }
            return View(estadoServicio);
        }

        // POST: EstadoServicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEstServ,Descripcion")] EstadoServicio estadoServicio)
        {
            if (id != estadoServicio.CodEstServ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoServicioExists(estadoServicio.CodEstServ))
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
            return View(estadoServicio);
        }

        // GET: EstadoServicio/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoServicio = await _context.EstadoServicio
                .FirstOrDefaultAsync(m => m.CodEstServ == id);
            if (estadoServicio == null)
            {
                return NotFound();
            }

            return View(estadoServicio);
        }

        // POST: EstadoServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var estadoServicio = await _context.EstadoServicio.FindAsync(id);
            _context.EstadoServicio.Remove(estadoServicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoServicioExists(string id)
        {
            return _context.EstadoServicio.Any(e => e.CodEstServ == id);
        }
    }
}
