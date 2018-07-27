using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Medida
{
    public class DetailsModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DetailsModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public Medidas Medidas { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medidas = await _context.Medidas.FirstOrDefaultAsync(m => m.CódigoUnidad == id);

            if (Medidas == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
