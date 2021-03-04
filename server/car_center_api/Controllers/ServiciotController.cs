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
    public class ServiciotController : Controller
    {
        private readonly ModelContext _context;

        public ServiciotController(ModelContext context)
        {
            _context = context;
        }

        // GET: Serviciot
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Serviciot.Include(s => s.CodTipoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Serviciot/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciot = await _context.Serviciot
                .Include(s => s.CodTipoNavigation)
                .FirstOrDefaultAsync(m => m.CodSer == id);
            if (serviciot == null)
            {
                return NotFound();
            }

            return View(serviciot);
        }

        // GET: Serviciot/Create
        public IActionResult Create()
        {
            ViewData["CodTipo"] = new SelectList(_context.TipoServicio, "CodTipo", "Descripcion");
            return View();
        }

        // POST: Serviciot/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodSer,CodTipo,VlrMin,VlrMax,DurMin")] Serviciot serviciot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviciot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodTipo"] = new SelectList(_context.TipoServicio, "CodTipo", "Descripcion", serviciot.CodTipo);
            return View(serviciot);
        }

        // GET: Serviciot/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciot = await _context.Serviciot.FindAsync(id);
            if (serviciot == null)
            {
                return NotFound();
            }
            ViewData["CodTipo"] = new SelectList(_context.TipoServicio, "CodTipo", "Descripcion", serviciot.CodTipo);
            return View(serviciot);
        }

        // POST: Serviciot/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodSer,CodTipo,VlrMin,VlrMax,DurMin")] Serviciot serviciot)
        {
            if (id != serviciot.CodSer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviciot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciotExists(serviciot.CodSer))
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
            ViewData["CodTipo"] = new SelectList(_context.TipoServicio, "CodTipo", "Descripcion", serviciot.CodTipo);
            return View(serviciot);
        }

        // GET: Serviciot/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciot = await _context.Serviciot
                .Include(s => s.CodTipoNavigation)
                .FirstOrDefaultAsync(m => m.CodSer == id);
            if (serviciot == null)
            {
                return NotFound();
            }

            return View(serviciot);
        }

        // POST: Serviciot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var serviciot = await _context.Serviciot.FindAsync(id);
            _context.Serviciot.Remove(serviciot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciotExists(byte id)
        {
            return _context.Serviciot.Any(e => e.CodSer == id);
        }
    }
}
