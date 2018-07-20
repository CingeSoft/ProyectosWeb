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
    public class TipoArticulosController : Controller
    {
        private readonly CingeWebContext _context;

        public TipoArticulosController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: TipoArticulos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoArticulos.ToListAsync());
        }

        // GET: TipoArticulos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArticulos = await _context.TipoArticulos
                .FirstOrDefaultAsync(m => m.TipoArticulo == id);
            if (tipoArticulos == null)
            {
                return NotFound();
            }

            return View(tipoArticulos);
        }

        // GET: TipoArticulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoArticulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoArticulo,NombreTipo")] TipoArticulos tipoArticulos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoArticulos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoArticulos);
        }

        // GET: TipoArticulos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArticulos = await _context.TipoArticulos.FindAsync(id);
            if (tipoArticulos == null)
            {
                return NotFound();
            }
            return View(tipoArticulos);
        }

        // POST: TipoArticulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoArticulo,NombreTipo")] TipoArticulos tipoArticulos)
        {
            if (id != tipoArticulos.TipoArticulo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoArticulos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoArticulosExists(tipoArticulos.TipoArticulo))
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
            return View(tipoArticulos);
        }

        // GET: TipoArticulos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArticulos = await _context.TipoArticulos
                .FirstOrDefaultAsync(m => m.TipoArticulo == id);
            if (tipoArticulos == null)
            {
                return NotFound();
            }

            return View(tipoArticulos);
        }

        // POST: TipoArticulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoArticulos = await _context.TipoArticulos.FindAsync(id);
            _context.TipoArticulos.Remove(tipoArticulos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoArticulosExists(string id)
        {
            return _context.TipoArticulos.Any(e => e.TipoArticulo == id);
        }
    }
}
