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
    public class ClienteController : Controller
    {
        private readonly ModelContext _context;

        public ClienteController(ModelContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Cliente.Include(c => c.CodZonaNavigation).Include(c => c.TipoDocNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.CodZonaNavigation)
                .Include(c => c.TipoDocNavigation)
                .FirstOrDefaultAsync(m => m.CodCli == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona");
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodCli,CodZona,TipoDoc,PrimNom,SeguNom,PrimApe,SeguApe,NroDoc,NroCel,Direccion,Email,VlrMax,FecReg")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", cliente.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", cliente.TipoDoc);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", cliente.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", cliente.TipoDoc);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodCli,CodZona,TipoDoc,PrimNom,SeguNom,PrimApe,SeguApe,NroDoc,NroCel,Direccion,Email,VlrMax,FecReg")] Cliente cliente)
        {
            if (id != cliente.CodCli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.CodCli))
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
            ViewData["CodZona"] = new SelectList(_context.Zonat, "CodZona", "NomZona", cliente.CodZona);
            ViewData["TipoDoc"] = new SelectList(_context.TipoDoc, "TipoDoc1", "TipoDoc1", cliente.TipoDoc);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.CodZonaNavigation)
                .Include(c => c.TipoDocNavigation)
                .FirstOrDefaultAsync(m => m.CodCli == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.CodCli == id);
        }
    }
}
