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
    public class ArticulosController : Controller
    {
        private readonly CingeWebContext _context;

        public ArticulosController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var cingeWebContext = _context.Articulos.Include(a => a.CódigoUnidadNavigation).Include(a => a.TipoArticuloNavigation);
            return View(await cingeWebContext.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .Include(a => a.CódigoUnidadNavigation)
                .Include(a => a.TipoArticuloNavigation)
                .FirstOrDefaultAsync(m => m.Código == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad");
            ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Código,Nombre,TipoArticulo,CódigoUnidad,CostoPromedio,MargenUtilida,PrecioVenta,PagaImpuesto,FechaCreacíon")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad", articulos.CódigoUnidad);
            ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo", articulos.TipoArticulo);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos.FindAsync(id);
            if (articulos == null)
            {
                return NotFound();
            }
            ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad", articulos.CódigoUnidad);
            ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo", articulos.TipoArticulo);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Código,Nombre,TipoArticulo,CódigoUnidad,CostoPromedio,MargenUtilida,PrecioVenta,PagaImpuesto,FechaCreacíon")] Articulos articulos)
        {
            if (id != articulos.Código)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticulosExists(articulos.Código))
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
            ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad", articulos.CódigoUnidad);
            ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo", articulos.TipoArticulo);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulos = await _context.Articulos
                .Include(a => a.CódigoUnidadNavigation)
                .Include(a => a.TipoArticuloNavigation)
                .FirstOrDefaultAsync(m => m.Código == id);
            if (articulos == null)
            {
                return NotFound();
            }

            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var articulos = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticulosExists(string id)
        {
            return _context.Articulos.Any(e => e.Código == id);
        }
    }
}
