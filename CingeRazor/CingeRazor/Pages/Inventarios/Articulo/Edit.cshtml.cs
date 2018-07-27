using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Articulo
{
    public class EditModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public EditModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Articulos Articulos { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Articulos = await _context.Articulos
                .Include(a => a.CódigoUnidadNavigation)
                .Include(a => a.TipoArticuloNavigation).FirstOrDefaultAsync(m => m.Código == id);

            if (Articulos == null)
            {
                return NotFound();
            }
           ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad");
           ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Articulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosExists(Articulos.Código))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ArticulosExists(string id)
        {
            return _context.Articulos.Any(e => e.Código == id);
        }
    }
}
