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
    public class SolicitudSerRepuestoController : Controller
    {
        private readonly ModelContext _context;

        public SolicitudSerRepuestoController(ModelContext context)
        {
            _context = context;
        }

        // GET: SolicitudSerRepuesto
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.SolicitudSerRepuesto.Include(s => s.CodRepNavigation).Include(s => s.CodSolicNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: SolicitudSerRepuesto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudSerRepuesto = await _context.SolicitudSerRepuesto
                .Include(s => s.CodRepNavigation)
                .Include(s => s.CodSolicNavigation)
                .FirstOrDefaultAsync(m => m.CodSolSerRep == id);
            if (solicitudSerRepuesto == null)
            {
                return NotFound();
            }

            return View(solicitudSerRepuesto);
        }

        // GET: SolicitudSerRepuesto/Create
        public IActionResult Create()
        {
            ViewData["CodRep"] = new SelectList(_context.Repuesto, "CodRep", "NomRep");
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic");
            return View();
        }

        // POST: SolicitudSerRepuesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodSolSerRep,CodSolic,CodRep,Cantidad")] SolicitudSerRepuesto solicitudSerRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitudSerRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodRep"] = new SelectList(_context.Repuesto, "CodRep", "NomRep", solicitudSerRepuesto.CodRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", solicitudSerRepuesto.CodSolic);
            return View(solicitudSerRepuesto);
        }

        // GET: SolicitudSerRepuesto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudSerRepuesto = await _context.SolicitudSerRepuesto.FindAsync(id);
            if (solicitudSerRepuesto == null)
            {
                return NotFound();
            }
            ViewData["CodRep"] = new SelectList(_context.Repuesto, "CodRep", "NomRep", solicitudSerRepuesto.CodRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", solicitudSerRepuesto.CodSolic);
            return View(solicitudSerRepuesto);
        }

        // POST: SolicitudSerRepuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodSolSerRep,CodSolic,CodRep,Cantidad")] SolicitudSerRepuesto solicitudSerRepuesto)
        {
            if (id != solicitudSerRepuesto.CodSolSerRep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitudSerRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudSerRepuestoExists(solicitudSerRepuesto.CodSolSerRep))
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
            ViewData["CodRep"] = new SelectList(_context.Repuesto, "CodRep", "NomRep", solicitudSerRepuesto.CodRep);
            ViewData["CodSolic"] = new SelectList(_context.SolicitudServ, "CodSolic", "CodSolic", solicitudSerRepuesto.CodSolic);
            return View(solicitudSerRepuesto);
        }

        // GET: SolicitudSerRepuesto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitudSerRepuesto = await _context.SolicitudSerRepuesto
                .Include(s => s.CodRepNavigation)
                .Include(s => s.CodSolicNavigation)
                .FirstOrDefaultAsync(m => m.CodSolSerRep == id);
            if (solicitudSerRepuesto == null)
            {
                return NotFound();
            }

            return View(solicitudSerRepuesto);
        }

        // POST: SolicitudSerRepuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitudSerRepuesto = await _context.SolicitudSerRepuesto.FindAsync(id);
            _context.SolicitudSerRepuesto.Remove(solicitudSerRepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudSerRepuestoExists(int id)
        {
            return _context.SolicitudSerRepuesto.Any(e => e.CodSolSerRep == id);
        }
    }
}
