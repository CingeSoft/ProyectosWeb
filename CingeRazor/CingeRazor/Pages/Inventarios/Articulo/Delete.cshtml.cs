using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Articulo
{
    public class DeleteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DeleteModel(CingeRazor.Models.CingeWebContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Articulos = await _context.Articulos.FindAsync(id);

            if (Articulos != null)
            {
                _context.Articulos.Remove(Articulos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
