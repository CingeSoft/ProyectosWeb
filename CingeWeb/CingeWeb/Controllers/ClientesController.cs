using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeWeb.Models;

namespace CingeWeb.Controllers
{
    public class ClientesController : Controller
    {
        private readonly CingeWebContext _context;

        public ClientesController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var cingeWebContext = _context.Clientes.Include(c => c.CódigoCédulaNavigation).Include(c => c.CódigoZonaNavigation);
            return View(await cingeWebContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.CódigoCédulaNavigation)
                .Include(c => c.CódigoZonaNavigation)
                .FirstOrDefaultAsync(m => m.Código == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CódigoCédula"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula");
            ViewData["CódigoZona"] = new SelectList(_context.Zonas, "CódigoZona", "CódigoZona");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Código,Nombre,Localidad,CódigoCédula,Cédula,TelefonoCodigoArea,Teléfono,Dirección,Email,FechaCreacíon,CódigoZona")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CódigoCédula"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula", clientes.CódigoCédula);
            ViewData["CódigoZona"] = new SelectList(_context.Zonas, "CódigoZona", "CódigoZona", clientes.CódigoZona);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            ViewData["CódigoCédula"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula", clientes.CódigoCédula);
            ViewData["CódigoZona"] = new SelectList(_context.Zonas, "CódigoZona", "CódigoZona", clientes.CódigoZona);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Código,Nombre,Localidad,CódigoCédula,Cédula,TelefonoCodigoArea,Teléfono,Dirección,Email,FechaCreacíon,CódigoZona")] Clientes clientes)
        {
            if (id != clientes.Código)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.Código))
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
            ViewData["CódigoCédula"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula", clientes.CódigoCédula);
            ViewData["CódigoZona"] = new SelectList(_context.Zonas, "CódigoZona", "CódigoZona", clientes.CódigoZona);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .Include(c => c.CódigoCédulaNavigation)
                .Include(c => c.CódigoZonaNavigation)
                .FirstOrDefaultAsync(m => m.Código == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(string id)
        {
            return _context.Clientes.Any(e => e.Código == id);
        }
    }
}
