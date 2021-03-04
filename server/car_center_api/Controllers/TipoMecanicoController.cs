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
    public class TipoMecanicoController : Controller
    {
        private readonly ModelContext _context;

        public TipoMecanicoController(ModelContext context)
        {
            _context = context;
        }

        // GET: TipoMecanico
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMecanico.ToListAsync());
        }

        // GET: TipoMecanico/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMecanico = await _context.TipoMecanico
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoMecanico == null)
            {
                return NotFound();
            }

            return View(tipoMecanico);
        }

        // GET: TipoMecanico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMecanico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTipo,Descripcion")] TipoMecanico tipoMecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMecanico);
        }

        // GET: TipoMecanico/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMecanico = await _context.TipoMecanico.FindAsync(id);
            if (tipoMecanico == null)
            {
                return NotFound();
            }
            return View(tipoMecanico);
        }

        // POST: TipoMecanico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CodTipo,Descripcion")] TipoMecanico tipoMecanico)
        {
            if (id != tipoMecanico.CodTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMecanicoExists(tipoMecanico.CodTipo))
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
            return View(tipoMecanico);
        }

        // GET: TipoMecanico/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMecanico = await _context.TipoMecanico
                .FirstOrDefaultAsync(m => m.CodTipo == id);
            if (tipoMecanico == null)
            {
                return NotFound();
            }

            return View(tipoMecanico);
        }

        // POST: TipoMecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var tipoMecanico = await _context.TipoMecanico.FindAsync(id);
            _context.TipoMecanico.Remove(tipoMecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMecanicoExists(byte id)
        {
            return _context.TipoMecanico.Any(e => e.CodTipo == id);
        }
    }
}
