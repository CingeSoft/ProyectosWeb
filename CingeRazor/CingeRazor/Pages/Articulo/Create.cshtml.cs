using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor.Pages.Articulo
{
    public class CreateModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public CreateModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CódigoUnidad"] = new SelectList(_context.Medidas, "CódigoUnidad", "CódigoUnidad");
        ViewData["TipoArticulo"] = new SelectList(_context.TipoArticulos, "TipoArticulo", "TipoArticulo");
            return Page();
        }

        [BindProperty]
        public Articulos Articulos { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Articulos.Add(Articulos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}