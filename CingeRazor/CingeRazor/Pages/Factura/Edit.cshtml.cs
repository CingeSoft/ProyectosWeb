using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Factura
{
    public class EditModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public EditModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventFactura InventFactura { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventFactura = await _context.InventFactura
                .Include(i => i.ClienteNavigation)
                .Include(i => i.TipoIdentificacionNavigation).FirstOrDefaultAsync(m => m.Consecutivo == id);

            if (InventFactura == null)
            {
                return NotFound();
            }
           ViewData["Cliente"] = new SelectList(_context.Clientes, "Código", "Código");
           ViewData["TipoIdentificacion"] = new SelectList(_context.Cedulas, "CódigoCédula", "CódigoCédula");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventFacturaExists(InventFactura.Consecutivo))
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

        private bool InventFacturaExists(string id)
        {
            return _context.InventFactura.Any(e => e.Consecutivo == id);
        }
    }
}
