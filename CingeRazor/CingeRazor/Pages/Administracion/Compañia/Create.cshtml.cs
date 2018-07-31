using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;
using System.IO;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace CingeRazor.Pages.Compañia
{
    public class CreateModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;
        private VariablesCinge _variables;
        private IHostingEnvironment _hostingEnvironment;

        public CreateModel(CingeRazor.Models.CingeWebContext context, IOptionsSnapshot<VariablesCinge> variables, IHostingEnvironment environment)
        {
            _context = context;
            _variables = variables.Value;
            _hostingEnvironment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Compañias Compañias { get; set; }
        [BindProperty]
        public IFormFile ArchivoImagen { get; set; }

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
                else
                    Compañias.DireccionLogo = "";
            }
            else
                Compañias.DireccionLogo = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Compañias.Add(Compañias);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}