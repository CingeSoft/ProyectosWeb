using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Mascota
{
    public class EditModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public EditModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascotas Mascotas { get; set; }
        public string Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mascotas = await _context.Mascotas
                .Include(m => m.CódigoNavigation).FirstOrDefaultAsync(m => m.CódigoMascota == id);

            if (Mascotas == null)
            {
                return NotFound();
            }
           ViewData["Código"] = new SelectList(_context.Clientes, "Código", "Código");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mascotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotasExists(Mascotas.CódigoMascota))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Clientes/Cliente/Index/", new { id = Mascotas.Código });
        }

        private bool MascotasExists(string id)
        {
            return _context.Mascotas.Any(e => e.CódigoMascota == id);
        }
    }
}
