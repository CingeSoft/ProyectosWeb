using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor
{
    public class DetailsModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DetailsModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public Roles Roles { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Roles = await _context.Roles.FirstOrDefaultAsync(m => m.IdRol == id);

            if (Roles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
