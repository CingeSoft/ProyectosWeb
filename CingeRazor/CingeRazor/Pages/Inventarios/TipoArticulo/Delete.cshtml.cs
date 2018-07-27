using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.TipoArticulo
{
    public class DeleteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DeleteModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoArticulos TipoArticulos { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoArticulos = await _context.TipoArticulos.FirstOrDefaultAsync(m => m.TipoArticulo == id);

            if (TipoArticulos == null)
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

            TipoArticulos = await _context.TipoArticulos.FindAsync(id);

            if (TipoArticulos != null)
            {
                _context.TipoArticulos.Remove(TipoArticulos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
