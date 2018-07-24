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
    public class DetailsModelUsuarios : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DetailsModelUsuarios(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public Usuarios Usuarios { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuarios = await _context.Usuarios
                .Include(u => u.IdRolNavigation).FirstOrDefaultAsync(m => m.Usuario == id);

            if (Usuarios == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
