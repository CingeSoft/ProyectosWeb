using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CingeRazor.Models;

namespace CingeRazor.Pages.Cedula
{
    public class CreateModel : PageModel
    {
        string date = String.Format("{0: D}", DateTime.Now);
        private readonly CingeRazor.Models.CingeWebContext _context;

        public CreateModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cedulas Cedulas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cedulas.Add(Cedulas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}