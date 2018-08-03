using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor.Pages.Mascota
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
            ViewData["Código"] = new SelectList(_context.Clientes, "Código", "Código");
            return Page();
        }

        [BindProperty]
        public Mascotas Mascotas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mascotas.Add(Mascotas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}