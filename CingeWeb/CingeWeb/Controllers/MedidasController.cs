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
    public class MedidasController : Controller
    {
        private readonly CingeWebContext _context;

        public MedidasController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Medidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medidas.ToListAsync());
        }

        // GET: Medidas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidas = await _context.Medidas
                .FirstOrDefaultAsync(m => m.CódigoUnidad == id);
            if (medidas == null)
            {
                return NotFound();
            }

            return View(medidas);
        }

        // GET: Medidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CódigoUnidad,NombreUnidad")] Medidas medidas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medidas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medidas);
        }

        // GET: Medidas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidas = await _context.Medidas.FindAsync(id);
            if (medidas == null)
            {
                return NotFound();
            }
            return View(medidas);
        }

        // POST: Medidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CódigoUnidad,NombreUnidad")] Medidas medidas)
        {
            if (id != medidas.CódigoUnidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medidas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedidasExists(medidas.CódigoUnidad))
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
            return View(medidas);
        }

        // GET: Medidas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidas = await _context.Medidas
                .FirstOrDefaultAsync(m => m.CódigoUnidad == id);
            if (medidas == null)
            {
                return NotFound();
            }

            return View(medidas);
        }

        // POST: Medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medidas = await _context.Medidas.FindAsync(id);
            _context.Medidas.Remove(medidas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedidasExists(string id)
        {
            return _context.Medidas.Any(e => e.CódigoUnidad == id);
        }
    }
}
