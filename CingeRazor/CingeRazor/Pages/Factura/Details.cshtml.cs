using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Factura
{
    public class DetailsModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DetailsModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
