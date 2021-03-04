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
    public class SerMecanicoController : Controller
    {
        private readonly ModelContext _context;

        public SerMecanicoController(ModelContext context)
        {
            _context = context;
        }

        // GET: SerMecanico
        public async Task<IActionResult> Index()
        {
            return View(await _context.SerMecanico.ToListAsync());
        }

        // GET: SerMecanico/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serMecanico = await _context.SerMecanico
                .FirstOrDefaultAsync(m => m.CodSer == id);
            if (serMecanico == null)
            {
                return NotFound();
            }

            return View(serMecanico);
        }

        // GET: SerMecanico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SerMecanico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodSer,CodMec")] SerMecanico serMecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serMecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serMecanico);
        }

        // GET: SerMecanico/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serMecanico = await _context.SerMecanico.FindAsync(id);
            if (serMecanico == null)
            {
                return NotFound();
            }
            return View(serMecanico);
        }

        // POST: SerMecanico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodSer,CodMec")] SerMecanico serMecanico)
        {
            if (id != serMecanico.CodSer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serMecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerMecanicoExists(serMecanico.CodSer))
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
            return View(serMecanico);
        }

        // GET: SerMecanico/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serMecanico = await _context.SerMecanico
                .FirstOrDefaultAsync(m => m.CodSer == id);
            if (serMecanico == null)
            {
                return NotFound();
            }

            return View(serMecanico);
        }

        // POST: SerMecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var serMecanico = await _context.SerMecanico.FindAsync(id);
            _context.SerMecanico.Remove(serMecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerMecanicoExists(byte id)
        {
            return _context.SerMecanico.Any(e => e.CodSer == id);
        }
    }
}
