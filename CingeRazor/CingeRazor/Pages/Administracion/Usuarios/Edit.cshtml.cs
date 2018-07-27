using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor
{
    public class EditModelUsuarios : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public EditModelUsuarios(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(Usuarios.Usuario))
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

        private bool UsuariosExists(string id)
        {
            return _context.Usuarios.Any(e => e.Usuario == id);
        }
    }
}
