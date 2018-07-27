using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Cliente
{
    public class DetailsModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DetailsModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public Clientes Clientes { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clientes = await _context.Clientes
                .Include(c => c.CódigoCédulaNavigation)
                .Include(c => c.CódigoZonaNavigation).FirstOrDefaultAsync(m => m.Código == id);

            if (Clientes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
