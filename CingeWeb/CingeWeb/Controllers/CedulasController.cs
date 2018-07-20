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
    public class CedulasController : Controller
    {
        private readonly CingeWebContext _context;

        public CedulasController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Cedulas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cedulas.ToListAsync());
        }

        // GET: Cedulas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas
                .FirstOrDefaultAsync(m => m.CódigoCédula == id);
            if (cedulas == null)
            {
                return NotFound();
            }

            return View(cedulas);
        }

        // GET: Cedulas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cedulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CódigoCédula,Cédula")] Cedulas cedulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cedulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cedulas);
        }

        // GET: Cedulas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas.FindAsync(id);
            if (cedulas == null)
            {
                return NotFound();
            }
            return View(cedulas);
        }

        // POST: Cedulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CódigoCédula,Cédula")] Cedulas cedulas)
        {
            if (id != cedulas.CódigoCédula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cedulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CedulasExists(cedulas.CódigoCédula))
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
            return View(cedulas);
        }

        // GET: Cedulas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cedulas = await _context.Cedulas
                .FirstOrDefaultAsync(m => m.CódigoCédula == id);
            if (cedulas == null)
            {
                return NotFound();
            }

            return View(cedulas);
        }

        // POST: Cedulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cedulas = await _context.Cedulas.FindAsync(id);
            _context.Cedulas.Remove(cedulas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CedulasExists(string id)
        {
            return _context.Cedulas.Any(e => e.CódigoCédula == id);
        }
    }
}
