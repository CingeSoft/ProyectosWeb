using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor
{
    public class CreateModelUsuarios : PageModel
    {
        string date = String.Format("{0: D}", DateTime.Now);
        
        private readonly CingeRazor.Models.CingeWebContext _context;

        public CreateModelUsuarios(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return Page();
        }

        [BindProperty]
        public Usuarios Usuarios { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Usuarios.FechaCreacion = DateTime.Now;
            Usuarios.UltimoLogeo = new DateTime(1900, 1, 1);
            Usuarios.Contraseñas = Usuarios.EncriptarContrasena(Usuarios.Contraseñas);

            _context.Usuarios.Add(Usuarios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}