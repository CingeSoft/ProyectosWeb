using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor.Pages.Factura
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
        ViewData["Cliente"] = new SelectList(_context.Clientes, "Código", "Código");
        ViewData["TipoIdentificacion"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula");
            return Page();
        }

        [BindProperty]
        public InventFactura InventFactura { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            InventFactura.Fecha = DateTime.Now;
            InventFactura.CreadoFecha = DateTime.Now;
            _context.InventFactura.Add(InventFactura);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}