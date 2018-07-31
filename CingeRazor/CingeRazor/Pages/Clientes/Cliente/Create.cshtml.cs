using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        string date = String.Format("{0: D}", DateTime.Now);
        private readonly CingeRazor.Models.CingeWebContext _context;

        public CreateModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CódigoCédula"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula");
        ViewData["CódigoZona"] = new SelectList(_context.Zonas, "CódigoZona", "CódigoZona");
            return Page();
        }

        [BindProperty]
        public Models.Clientes Clientes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Clientes.FechaCreacíon = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Clientes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}