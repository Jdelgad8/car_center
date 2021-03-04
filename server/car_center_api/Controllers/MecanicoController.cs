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
    public class MecanicoController : Controller
    {
        private readonly ModelContext _context;

        public MecanicoController(ModelContext context)
        {
            _context = context;
        }

        // GET: Mecanico
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Mecanico.Include(m => m.CodEstMecNavigation).Include(m => m.CodTallerNavigation).Include(m => m.CodTipoNavigation).Include(m => m.CodZonaNavigation).Include(m => m.TipoDocNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Mecanico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanico
                .Include(m => m.CodEstMecNavigation)
                .Include(m => m.CodTallerNavigation)
                .Include(m => m.CodTipoNavigation)
                .Include(m => m.CodZonaNavigation)
                .Include(m => m.TipoDocNavigation)
                .FirstOrDefaultAsync(m => m.CodMec == id);
            if (mecanico == null)
            {
                return NotFound();
            }

            return View(mecanico);
        }

        // GET: Mecanico/Create
        public IActionResult Create()
        {
            ViewData["CodEstMec"] = new SelectList(_context.EstadoMecanico, "CodEstMec", "CodEstMec");
            ViewData["CodTaller"] = new SelectList(_context.Taller, "CodTaller", "Direccion");
            ViewData["CodTipo"] = new SelectList(_context.TipoMecanico, "CodTipo", "Descripcion");
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona");
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1");
            return View();
        }

        // POST: Mecanico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodMec,CodZona,CodTaller,CodTipo,TipoDoc,CodEstMec,PrimNom,SeguNom,PrimApe,SeguApe,NroDoc,NroCel,Direccion,Email,FecReg")] Mecanico mecanico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mecanico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodEstMec"] = new SelectList(_context.EstadoMecanico, "CodEstMec", "CodEstMec", mecanico.CodEstMec);
            ViewData["CodTaller"] = new SelectList(_context.Taller, "CodTaller", "Direccion", mecanico.CodTaller);
            ViewData["CodTipo"] = new SelectList(_context.TipoMecanico, "CodTipo", "Descripcion", mecanico.CodTipo);
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", mecanico.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", mecanico.TipoDoc);
            return View(mecanico);
        }

        // GET: Mecanico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanico.FindAsync(id);
            if (mecanico == null)
            {
                return NotFound();
            }
            ViewData["CodEstMec"] = new SelectList(_context.EstadoMecanico, "CodEstMec", "CodEstMec", mecanico.CodEstMec);
            ViewData["CodTaller"] = new SelectList(_context.Taller, "CodTaller", "Direccion", mecanico.CodTaller);
            ViewData["CodTipo"] = new SelectList(_context.TipoMecanico, "CodTipo", "Descripcion", mecanico.CodTipo);
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", mecanico.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", mecanico.TipoDoc);
            return View(mecanico);
        }

        // POST: Mecanico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodMec,CodZona,CodTaller,CodTipo,TipoDoc,CodEstMec,PrimNom,SeguNom,PrimApe,SeguApe,NroDoc,NroCel,Direccion,Email,FecReg")] Mecanico mecanico)
        {
            if (id != mecanico.CodMec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mecanico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MecanicoExists(mecanico.CodMec))
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
            ViewData["CodEstMec"] = new SelectList(_context.EstadoMecanico, "CodEstMec", "CodEstMec", mecanico.CodEstMec);
            ViewData["CodTaller"] = new SelectList(_context.Taller, "CodTaller", "Direccion", mecanico.CodTaller);
            ViewData["CodTipo"] = new SelectList(_context.TipoMecanico, "CodTipo", "Descripcion", mecanico.CodTipo);
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", mecanico.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", mecanico.TipoDoc);
            return View(mecanico);
        }

        // GET: Mecanico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mecanico = await _context.Mecanico
                .Include(m => m.CodEstMecNavigation)
                .Include(m => m.CodTallerNavigation)
                .Include(m => m.CodTipoNavigation)
                .Include(m => m.CodZonaNavigation)
                .Include(m => m.TipoDocNavigation)
                .FirstOrDefaultAsync(m => m.CodMec == id);
            if (mecanico == null)
            {
                return NotFound();
            }

            return View(mecanico);
        }

        // POST: Mecanico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mecanico = await _context.Mecanico.FindAsync(id);
            _context.Mecanico.Remove(mecanico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MecanicoExists(int id)
        {
            return _context.Mecanico.Any(e => e.CodMec == id);
        }
    }
}
