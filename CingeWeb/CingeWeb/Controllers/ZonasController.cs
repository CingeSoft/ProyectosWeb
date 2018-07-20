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
    public class ZonasController : Controller
    {
        private readonly CingeWebContext _context;

        public ZonasController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Zonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zonas.ToListAsync());
        }

        // GET: Zonas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .FirstOrDefaultAsync(m => m.CódigoZona == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // GET: Zonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CódigoZona,NombreZona")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zonas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zonas);
        }

        // GET: Zonas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas.FindAsync(id);
            if (zonas == null)
            {
                return NotFound();
            }
            return View(zonas);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CódigoZona,NombreZona")] Zonas zonas)
        {
            if (id != zonas.CódigoZona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zonas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZonasExists(zonas.CódigoZona))
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
            return View(zonas);
        }

        // GET: Zonas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zonas = await _context.Zonas
                .FirstOrDefaultAsync(m => m.CódigoZona == id);
            if (zonas == null)
            {
                return NotFound();
            }

            return View(zonas);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zonas = await _context.Zonas.FindAsync(id);
            _context.Zonas.Remove(zonas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZonasExists(string id)
        {
            return _context.Zonas.Any(e => e.CódigoZona == id);
        }
    }
}
