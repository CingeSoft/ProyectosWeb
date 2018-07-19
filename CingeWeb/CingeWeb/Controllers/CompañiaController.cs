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
    public class CompañiaController : Controller
        
    {
        private readonly CingeWebContext _context;

        public CompañiaController(CingeWebContext context)
        {
            _context = context;
        }

        // GET: Compañia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compañia.ToListAsync());
        }

        // GET: Compañia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia
                .FirstOrDefaultAsync(m => m.IdCompañia == id);
            if (compañia == null)
            {
                return NotFound();
            }

            return View(compañia);
        }

        // GET: Compañia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compañia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompañia,NombreCompañia,Telefono,Fax,ApartadoPostal,Direccion,CedulaJuridica,Correo,PaginaWeb,FacturaElectronica,DireccionLogo")] Compañia compañia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compañia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compañia);
        }

        // GET: Compañia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia.FindAsync(id);
            if (compañia == null)
            {
                return NotFound();
            }
            return View(compañia);
        }

        // POST: Compañia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCompañia,NombreCompañia,Telefono,Fax,ApartadoPostal,Direccion,CedulaJuridica,Correo,PaginaWeb,FacturaElectronica,DireccionLogo")] Compañia compañia)
        {
            if (id != compañia.IdCompañia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compañia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompañiaExists(compañia.IdCompañia))
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
            return View(compañia);
        }

        // GET: Compañia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compañia = await _context.Compañia
                .FirstOrDefaultAsync(m => m.IdCompañia == id);
            if (compañia == null)
            {
                return NotFound();
            }

            return View(compañia);
        }

        // POST: Compañia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var compañia = await _context.Compañia.FindAsync(id);
            _context.Compañia.Remove(compañia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompañiaExists(string id)
        {
            return _context.Compañia.Any(e => e.IdCompañia == id);
        }
                
       
    }
}
