using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Options;

namespace CingeRazor.Pages.Compañia
{
    public class EditModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;
        private VariablesCinge _variables;
        private IHostingEnvironment _hostingEnvironment;

        public EditModel(CingeRazor.Models.CingeWebContext context, IOptionsSnapshot<VariablesCinge> variables, IHostingEnvironment environment)
        {
            _context = context;
            _variables = variables.Value;
            _hostingEnvironment = environment;
        }

        [BindProperty]
        public Compañias Compañias { get; set; }
        [BindProperty]
        public IFormFile ArchivoImagen { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compañias = await _context.Compañias.FirstOrDefaultAsync(m => m.IdCompañia == id);

            if (Compañias == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ArchivoImagen != null)
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _variables.CarpetaArchivos, "Companias", string.Format("logo{0}{1}", Compañias.IdCompañia, Path.GetExtension(ArchivoImagen.FileName)));
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                if (ArchivoImagen.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ArchivoImagen.CopyToAsync(stream);
                    }
                    Compañias.DireccionLogo = Path.Combine("~", _variables.CarpetaArchivos, "Companias", string.Format("logo{0}{1}", Compañias.IdCompañia, Path.GetExtension(ArchivoImagen.FileName))).Replace("\\", "/");
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Compañias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompañiasExists(Compañias.IdCompañia))
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

        private bool CompañiasExists(string id)
        {
            return _context.Compañias.Any(e => e.IdCompañia == id);
        }
    }
}
