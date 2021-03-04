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
    public class TipoDocController : Controller
    {
        private readonly ModelContext _context;

        public TipoDocController(ModelContext context)
        {
            _context = context;
        }

        // GET: TipoDoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDoc.ToListAsync());
        }

        // GET: TipoDoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc
                .FirstOrDefaultAsync(m => m.TipoDoc1 == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // GET: TipoDoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDoc1,Descripcion")] TipoDoc tipoDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDoc);
        }

        // GET: TipoDoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc.FindAsync(id);
            if (tipoDoc == null)
            {
                return NotFound();
            }
            return View(tipoDoc);
        }

        // POST: TipoDoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoDoc1,Descripcion")] TipoDoc tipoDoc)
        {
            if (id != tipoDoc.TipoDoc1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocExists(tipoDoc.TipoDoc1))
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
            return View(tipoDoc);
        }

        // GET: TipoDoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDoc
                .FirstOrDefaultAsync(m => m.TipoDoc1 == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // POST: TipoDoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoDoc = await _context.TipoDoc.FindAsync(id);
            _context.TipoDoc.Remove(tipoDoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocExists(string id)
        {
            return _context.TipoDoc.Any(e => e.TipoDoc1 == id);
        }
    }
}
